using System;
using RailwayConformityApp.Enums;

namespace RailwayConformityApp.Models
{
    public class Tolerance
    {
        public int Id { get; set; }
        public ElementType ElementType { get; set; }
        public double GaugeMin { get; set; }
        public double GaugeMax { get; set; }
        public double LevelMax { get; set; }
        public double ArrowMax { get; set; }
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