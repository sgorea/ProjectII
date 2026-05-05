using System;
using System.Collections.Generic;
using System.Linq;

namespace RailwayConformityApp.Models
{
    public class ConformityReport
    {
        public int Id { get; set; }
        public DateTime GeneratedAt { get; set; }
        public string LineSection { get; set; }

        public List<ConformityResult> Results { get; set; }

        public int GeneratedBy { get; set; }

        public ConformityReport()
        {
            GeneratedAt = DateTime.Now;
            Results = new List<ConformityResult>();
        }

        public void Generate()
        {
        
        }

        public byte[] ExportToPdf()
        {
            return new byte[0];
        }

        public List<ConformityResult> GetNonConformItems()
        {
            return Results.Where(r => !r.IsConform()).ToList();
        }
    }
}