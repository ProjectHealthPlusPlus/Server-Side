using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class AppointmentDetailsResponse : BaseResponse
    {
        public AppointmentDetails AppointmentDetails { get; private set; }

        public AppointmentDetailsResponse(bool success, string message, AppointmentDetails appointmentDetails) : base(success, message)
        {
            AppointmentDetails = appointmentDetails;
        }

        public AppointmentDetailsResponse(AppointmentDetails appointmentDetails) : this(true, string.Empty, appointmentDetails){}
        
        public AppointmentDetailsResponse(string message) : this(false, message, null){}
    }
}