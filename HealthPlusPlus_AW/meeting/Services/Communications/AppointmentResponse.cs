using HealthPlusPlus_AW.meeting.Domain.Models;
using HealthPlusPlus_AW.Shared.Services.Communications;

namespace HealthPlusPlus_AW.meeting.Services.Communications
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