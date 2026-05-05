using System;

namespace RailwayConformityApp.Models
{
    public class CurveRadius : TrackElement
    {
        public int TrackElementId { get; set; }
        public double MeasuredArrow { get; set; }
        public double ChordLength { get; set; }
        public double CalculatedRadius { get; set; }

        public double Calculate()
        {
            if (MeasuredArrow <= 0)
            {
                CalculatedRadius = 0;
                return 0;
            }

            CalculatedRadius = (Math.Pow(ChordLength, 2) / (8 * MeasuredArrow)) + (MeasuredArrow / 2);

            return CalculatedRadius;
        }

        public bool IsWithinDesignRadius()
        {
            return CalculatedRadius > 150;
        }
    }
}