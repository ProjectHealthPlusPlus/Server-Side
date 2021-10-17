using System.Collections.Generic;

namespace HealthPlusPlus_AW.Resources
{
    public class ClinicResource : UserResource
    {
        public ClinicLocationResource ClinicLocationResource { get; set; }
        public IList<MedicalHistoryResource> MedicalHistories { get; set; } = new List<MedicalHistoryResource>();
    }
}