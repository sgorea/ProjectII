using System;
using System.Collections.Generic;

namespace RailwayConformityApp.Models
{
    public class Measurement
    {
        public int Id { get; set; }

        public int ElementId { get; set; }
        public int OperatorId { get; set; }
        public int TrackElementId { get; set; } 
        public double Gauge { get; set; }
        public double Level { get; set; }
        public double Arrow { get; set; }
        public DateTime MeasuredAt { get; set; }
        

        public Measurement()
        {
            MeasuredAt = DateTime.Now;
        }

        public bool Validate()
        {
            if (Gauge <= 0 || Level < 0 || Arrow < 0)
                return false;

            return true;
        }
        public ConformityResult GetConformity()
        {
            return new ConformityResult();
        }
    }
}