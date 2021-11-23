using System.Collections.Generic;
using HealthPlusPlus_AW.Profile.Domain.Models;

namespace HealthPlusPlus_AW.meeting.Domain.Models
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