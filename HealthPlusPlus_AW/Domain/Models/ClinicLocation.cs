using System.Collections.Generic;

namespace HealthPlusPlus_AW.Domain.Models
{
    public class ClinicLocation
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string CapitalCity { get; set; }
        public string Country { get; set; }
        
        //RelationShips
        public IList<Clinic> Clinics { get; set; } = new List<Clinic>();
    }
}