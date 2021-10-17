using System.Collections.Generic;

namespace HealthPlusPlus_AW.Resources
{
    public class Clinic : User
    {
        public ClinicLocation ClinicLocation { get; set; }
        public IList<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();
    }
}