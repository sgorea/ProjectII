using System;

namespace RailwayConformityApp.Models
{
    public class TrackDevice : TrackElement
    {
        public string DeviceType { get; set; }

        public int TrackElementId { get; set; }

        public double[] Points { get; set; }

        public DateTime MeasuredAt { get; set; }

        public int OperatorId { get; set; }

        public TrackDevice()
        {
            MeasuredAt = DateTime.Now;
            Points = new double[0];
        }

        public double CalculateDeviation()
        {
            if (Points == null || Points.Length == 0) return 0;

            double sum = 0;
            foreach (var p in Points) sum += p;
            return sum / Points.Length;
        }

      
        public bool IsWithinTolerance()
        {
            double deviation = CalculateDeviation();
            return Math.Abs(deviation) < 5.0;
        }
    }
}