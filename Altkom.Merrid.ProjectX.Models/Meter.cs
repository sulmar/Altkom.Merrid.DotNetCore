namespace Altkom.Merrid.ProjectX.Models
{
    public class Meter : Base
    {
        // snippet: prop + 2 tab
        public int Id { get; set; }
        public string Address { get; set; }
        public string Firmware { get; set; }
        public string Name { get; set; }
        public bool IsPowerOn { get; set; }

    }
}
