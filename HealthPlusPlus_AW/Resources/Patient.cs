using System.Collections.Generic;

namespace HealthPlusPlus_AW.Resources
{
    public class Patient : User
    {
        public string Address { get; set; }

        public IList<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();
    }
}