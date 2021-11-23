using HealthPlusPlus_AW.Profile.Domain.Models;
using HealthPlusPlus_AW.Shared.Services.Communications;

namespace HealthPlusPlus_AW.Profile.Services.Communications
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