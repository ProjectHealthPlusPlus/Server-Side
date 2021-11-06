using System.Collections.Generic;

namespace HealthPlusPlus_AW.Domain.Models
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