using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class AppointmentResponse : BaseResponse
    {
        public Appointment Appointment { get; private set; }

        public AppointmentResponse(bool success, string message, Appointment appointment) : base(success, message)
        {
            Appointment = appointment;
        }

        public AppointmentResponse(Appointment appointment) : this(true, string.Empty, appointment){}
        
        public AppointmentResponse(string message) : this(false, message, null){}
    }
}