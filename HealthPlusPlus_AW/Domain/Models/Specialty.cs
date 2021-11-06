using System.Collections.Generic;
namespace HealthPlusPlus_AW.Domain.Models
{
    public class Specialty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        //RelationShips
        public IList<Diagnostic> Diagnostics { get; set; } = new List<Diagnostic>();
        public IList<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}