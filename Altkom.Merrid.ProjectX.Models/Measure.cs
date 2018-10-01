using System;

namespace Altkom.Merrid.ProjectX.Models
{
    public class Measure : Base
    {
        public long Id { get; set; }
        public DateTime MeasureDate { get; set; }
        public Meter Meter { get; set; }
        public float Value { get; set; }
        public Unit Unit { get; set; }
    }
}
