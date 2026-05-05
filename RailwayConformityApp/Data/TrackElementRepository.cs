using System;
using System.Collections.Generic;
using System.Data.SQLite;
using RailwayConformityApp.Models;
using RailwayConformityApp.Enums;

namespace RailwayConformityApp.Data
{
    public class TrackElementRepository : IRepository<TrackElement>
    {
        private readonly SQLiteDatabase _db;

        public TrackElementRepository()
        {
            _db = new SQLiteDatabase();
        }

        public void Save(TrackElement entity)
        {
            using (var conn = _db.Connect())
            {
                string sql = "INSERT INTO TrackElements (Name, Type, LineSection, Position, IsActive) " +
                             "VALUES (@name, @type, @section, @pos, @active)";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", entity.Name);
                    cmd.Parameters.AddWithValue("@type", (int)entity.Type);
                    cmd.Parameters.AddWithValue("@section", entity.LineSection);
                    cmd.Parameters.AddWithValue("@pos", entity.Position);
                    cmd.Parameters.AddWithValue("@active", entity.IsActive ? 1 : 0);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TrackElement> GetAll()
        {
            var list = new List<TrackElement>();
            using (var conn = _db.Connect())
            {
                string sql = "SELECT * FROM TrackElements";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TrackElement
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Type = (ElementType)Convert.ToInt32(reader["Type"]),
                                LineSection = reader["LineSection"].ToString(),
                                Position = Convert.ToDouble(reader["Position"]),
                                IsActive = Convert.ToInt32(reader["IsActive"]) == 1
                            });
                        }
                    }
                }
            }
            return list;
        }
        public void Delete(int id) { }
        public TrackElement GetById(int id) { return null; }
        public List<TrackElement> GetByFilter(string filter) { return null; }
    }
}