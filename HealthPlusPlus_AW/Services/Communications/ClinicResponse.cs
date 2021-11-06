using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class ClinicResponse : BaseResponse<Clinic>

    {
        public ClinicResponse(string message) : base(message)
        {
        }

        public ClinicResponse(Clinic clinic) : base(clinic)
        {
        }
    }
}