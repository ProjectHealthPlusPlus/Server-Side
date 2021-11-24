using System.Collections.Generic;
using HealthPlusPlus_AW.Heal.Domain.Models;
using HealthPlusPlus_AW.meeting.Domain.Models;
using HealthPlusPlus_AW.Profile.Domain.Repositories;

namespace HealthPlusPlus_AW.Profile.Domain.Models
{
    public class Clinic : User
    {
        //RelationShips
        public int ClinicLocationId { get; set; }
        public ClinicLocation ClinicLocation { get; set; }
        public IList<Doctor> Doctors { get; set; } = new List<Doctor>();
        public IList<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();
    }
}