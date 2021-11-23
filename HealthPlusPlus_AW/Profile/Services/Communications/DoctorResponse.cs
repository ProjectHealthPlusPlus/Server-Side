using HealthPlusPlus_AW.Profile.Domain.Models;
using HealthPlusPlus_AW.Shared.Services.Communications;

namespace HealthPlusPlus_AW.Profile.Services.Communications
{
    public class DoctorResponse : BaseResponse<Doctor>

    {
        public DoctorResponse(string message) : base(message)
        {
        }

        public DoctorResponse(Doctor doctor) : base(doctor)
        {
        }
    }
}