using System.Collections.Generic;
using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Resources
{
    public class DoctorResource : UserResource
    {
        public SpecialtyResource Specialty { get; set; }
        public ClinicResource Clinic { get; set; }
    }
}