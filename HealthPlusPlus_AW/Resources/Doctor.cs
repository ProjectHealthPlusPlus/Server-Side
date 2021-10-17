using System.Collections.Generic;

namespace HealthPlusPlus_AW.Resources
{
    public class Doctor : User
    {
        public IList<Specialty> Specialties { get; set; } = new List<Specialty>();
        public IList<Clinic> Clinics { get; set; } = new List<Clinic>();
    }
}