using System;
using RailwayConformityApp.Enums;

namespace RailwayConformityApp.Models
{
    public class ConformityResult
    {
        public int MeasurementId { get; set; }
        public LineStatus Status { get; set; }
        public bool GaugeOk { get; set; }
        public bool LevelOk { get; set; }
        public bool ArrowOk { get; set; }
        public DateTime EvaluatedAt { get; set; }

        public ConformityResult()
        {
            EvaluatedAt = DateTime.Now;
            Status = LineStatus.Normal;
        }
        public bool IsConform()
        {
            return GaugeOk && LevelOk && ArrowOk;
        }

        public string GetSummary()
        {
            string verdict = IsConform() ? "ADMIS" : "RESPINS";
            return $"[{EvaluatedAt:dd.MM.yyyy}] Rezultat: {verdict} | Status Linie: {Status}";
        }
    }
}