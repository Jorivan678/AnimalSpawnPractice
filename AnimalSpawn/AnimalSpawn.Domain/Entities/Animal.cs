using System;
using System.Collections.Generic;

namespace AnimalSpawn.Domain.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Gender { get; set; }
        public DateTime? CaptureDate { get; set; }
        public string CaptureCondition { get; set; }
        public string Description { get; set; }
        public int? EstimatedAge { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
    }
}
