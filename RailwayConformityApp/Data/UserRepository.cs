using System;
using System.Collections.Generic;
using System.Data.SQLite;
using RailwayConformityApp.Models;
using RailwayConformityApp.Enums;

namespace RailwayConformityApp.Data
{
    public class UserRepository
    {
        private readonly SQLiteDatabase _db = new SQLiteDatabase();

        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            using (var conn = _db.Connect())
            {
                string sql = "SELECT * FROM Users";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User(
                                Convert.ToInt32(reader["Id"]),
                                reader["Username"].ToString(),
                                (UserRole)Convert.ToInt32(reader["Role"])
                            ));
                        }
                    }
                }
            }
            return users;
        }
    }
}