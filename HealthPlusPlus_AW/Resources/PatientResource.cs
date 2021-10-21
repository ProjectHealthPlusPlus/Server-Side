using System.Collections.Generic;

namespace HealthPlusPlus_AW.Resources
{
    public class PatientResource : UserResource
    {
        public string Address { get; set; }

        public IList<MedicalHistoryResource> MedicalHistories { get; set; } = new List<MedicalHistoryResource>();
    }
}