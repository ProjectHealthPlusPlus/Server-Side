using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class SaveAppointmentResponse : BaseResponse
    {
        public Appointment Appointment { get; private set; }

        public SaveAppointmentResponse(bool success, string message, Appointment appointment) : base(success, message)
        {
            Appointment = appointment;
        }

        public SaveAppointmentResponse(Appointment appointment) : this(true, string.Empty, appointment){}
        
        public SaveAppointmentResponse(string message) : this(false, message, null){}
    }
}