using System;
using RailwayConformityApp.Enums;

namespace RailwayConformityApp.Models
{
    public class Tolerance
    {
        public int Id { get; set; }
        public ElementType ElementType { get; set; }
        public double GaugeMin { get; set; } = 1432.0;
        public double GaugeMax { get; set; } = 1438.0;
        public double LevelMax { get; set; } = 3.0;
        public double ArrowMax { get; set; } = 4.0;
        public int SpeedClass { get; set; }

        public bool IsWithin(Measurement m)
        {
            bool gaugeOk = m.Gauge >= GaugeMin && m.Gauge <= GaugeMax;

            bool levelOk = m.Level <= LevelMax;

            bool arrowOk = m.Arrow <= ArrowMax;

            return gaugeOk && levelOk && arrowOk;
        }

        public double GetMargin()
        {
            return GaugeMax - GaugeMin;
        }
    }
}