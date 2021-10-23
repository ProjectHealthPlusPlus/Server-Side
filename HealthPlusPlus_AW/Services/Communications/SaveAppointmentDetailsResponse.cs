using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class SaveAppointmentDetailsResponse : BaseResponse
    {
        public AppointmentDetails AppointmentDetails { get; private set; }

        public SaveAppointmentDetailsResponse(bool success, string message, AppointmentDetails appointmentDetails) : base(success, message)
        {
            AppointmentDetails = appointmentDetails;
        }

        public SaveAppointmentDetailsResponse(AppointmentDetails appointmentDetails) : this(true, string.Empty, appointmentDetails){}
        
        public SaveAppointmentDetailsResponse(string message) : this(false, message, null){}
    }
}