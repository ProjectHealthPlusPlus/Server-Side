using HealthPlusPlus_AW.meeting.Domain.Models;
using HealthPlusPlus_AW.Shared.Services.Communications;

namespace HealthPlusPlus_AW.meeting.Services.Communications
{
    public class AppointmentDetailsResponse : BaseResponse<AppointmentDetails>

    {
        public AppointmentDetailsResponse(string message) : base(message)
        {
        }

        public AppointmentDetailsResponse(AppointmentDetails appointmentDetails) : base(appointmentDetails)
        {
        }
    }
}