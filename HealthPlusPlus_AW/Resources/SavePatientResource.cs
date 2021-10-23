using System.Collections.Generic;
using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Resources
{
    public class SavePatientResource : UserResource
    {
        public string Address { get; set; }

        public IList<MedicalHistoryResource> MedicalHistories { get; set; } = new List<MedicalHistoryResource>();
    }
}