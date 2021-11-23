using HealthPlusPlus_AW.Heal.Resource;

namespace HealthPlusPlus_AW.Profile.Resource
{
    public class DoctorResource : UserResource
    {
        public SpecialtyResource Specialty { get; set; }
        public ClinicResource Clinic { get; set; }
    }
}