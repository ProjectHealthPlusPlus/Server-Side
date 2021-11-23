using HealthPlusPlus_AW.meeting.Domain.Models;
using HealthPlusPlus_AW.Shared.Services.Communications;

namespace HealthPlusPlus_AW.meeting.Services.Communications
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