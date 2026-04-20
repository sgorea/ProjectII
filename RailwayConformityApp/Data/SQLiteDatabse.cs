using System;
using System.Data.SQLite;
using System.IO;

namespace RailwayConformityApp.Data
{
    public class SQLiteDatabase
    {
        private string connectionString;
        private string dbFileName = "RailwayData.db";

        public SQLiteDatabase()
        {
            connectionString = $"Data Source={dbFileName};Version=3;";
        }

        public SQLiteConnection Connect()
        {
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            return connection;
        }

        public void Migrate()
        {
            if (!File.Exists(dbFileName))
            {
                SQLiteConnection.CreateFile(dbFileName);
            }

            using (var conn = Connect())
            {
                string sql = @"
                    CREATE TABLE IF NOT EXISTS TrackElements (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT,
                        Type INTEGER,
                        LineSection TEXT,
                        Position REAL,
                        IsActive INTEGER
                    );
                    
                    CREATE TABLE IF NOT EXISTS Measurements (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        TrackElementId INTEGER,
                        Gauge REAL,
                        Level REAL,
                        Arrow REAL,
                        MeasuredAt TEXT,
                        OperatorId INTEGER
                    );

                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT,
                        Role INTEGER
                    );";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                string seedUsers = @"
                    INSERT OR IGNORE INTO Users (Id, Username, Role) VALUES (1, 'Ion Muncitorul', 0);
                    INSERT OR IGNORE INTO Users (Id, Username, Role) VALUES (2, 'Andrei Inginer', 1);
                    INSERT OR IGNORE INTO Users (Id, Username, Role) VALUES (3, 'Admin Sef', 2);";

                using (var cmdSeed = new SQLiteCommand(seedUsers, conn))
                {
                    cmdSeed.ExecuteNonQuery();
                }
            }
        }

        public void ExecuteQuery(string query)
        {
            using (var conn = Connect())
            {
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}