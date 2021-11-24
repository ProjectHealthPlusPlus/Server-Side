using System.Collections.Generic;
using HealthPlusPlus_AW.Profile.Domain.Models;

namespace HealthPlusPlus_AW.Heal.Domain.Models
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