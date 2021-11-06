using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class AppointmentResponse : BaseResponse<Appointment>
    {
        public AppointmentResponse(string message) : base(message)
        {
        }

        public AppointmentResponse(Appointment appointment) : base(appointment)
        {
        }
    }
}