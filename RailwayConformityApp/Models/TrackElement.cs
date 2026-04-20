using System;
using System.Collections.Generic;
using RailwayConformityApp.Enums;

namespace RailwayConformityApp.Models
{
    public class TrackElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ElementType Type { get; set; } 
        public string LineSection { get; set; }
        public double Position { get; set; }
        public bool IsActive { get; set; }

        public virtual List<object> GetMeasurements()
        {
            return new List<object>();
        }
    }
}