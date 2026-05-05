using System;
using System.Collections.Generic;
using System.Data.SQLite;
using RailwayConformityApp.Models;

namespace RailwayConformityApp.Data
{
    public class MeasurementRepository
    {
        private string _connectionString = "Data Source=RailwayData.db;Version=3;";

        // Metoda CRUCIALĂ pentru raport: ia toate măsurătorile unui anumit element
        public List<Measurement> GetByElementId(int elementId)
        {
            var list = new List<Measurement>();

            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Measurements WHERE ElementId = @eid ORDER BY MeasuredAt DESC";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@eid", elementId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Measurement
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ElementId = Convert.ToInt32(reader["ElementId"]),
                                OperatorId = Convert.ToInt32(reader["OperatorId"]),
                                Gauge = Convert.ToDouble(reader["Gauge"]),
                                Level = Convert.ToDouble(reader["Level"]),
                                Arrow = Convert.ToDouble(reader["Arrow"]),
                                MeasuredAt = Convert.ToDateTime(reader["MeasuredAt"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        // Metodă pentru Muncitor (să poată salva măsurători noi)
        public void Save(Measurement m)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Measurements (ElementId,OperatorId, Gauge, Level, Arrow, MeasuredAt) " +
                             "VALUES (@eid,@oid, @g, @l, @a, @d)";
                
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@eid", m.ElementId);
                    cmd.Parameters.AddWithValue("@oid", m.OperatorId);
                    cmd.Parameters.AddWithValue("@g", m.Gauge);
                    cmd.Parameters.AddWithValue("@l", m.Level);
                    cmd.Parameters.AddWithValue("@a", m.Arrow);
                    cmd.Parameters.AddWithValue("@d", m.MeasuredAt);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}