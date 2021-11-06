using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
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