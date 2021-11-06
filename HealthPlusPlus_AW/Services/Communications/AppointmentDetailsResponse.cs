using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
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