using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class ClinicLocationResponse : BaseResponse<ClinicLocation>
    {
        public ClinicLocationResponse(string message) : base(message)
        {
        }

        public ClinicLocationResponse(ClinicLocation clinicLocation) : base(clinicLocation)
        {
        }
    }
}