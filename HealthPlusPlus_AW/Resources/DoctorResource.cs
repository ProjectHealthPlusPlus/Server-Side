using System.Collections.Generic;

namespace HealthPlusPlus_AW.Resources
{
    public class DoctorResource : UserResource
    {
        public IList<SpecialtyResource> Specialties { get; set; } = new List<SpecialtyResource>();
        public IList<ClinicResource> Clinics { get; set; } = new List<ClinicResource>();
    }
}