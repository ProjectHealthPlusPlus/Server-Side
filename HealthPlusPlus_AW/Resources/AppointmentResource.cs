using System;

namespace HealthPlusPlus_AW.Resources
{
    public class AppointmentResource
    {
        public int Id { get; set; }
        public DateTime StartAt { get; set; }
        
        public UserResource User { get; set; }
        public DoctorResource Doctor { get; set; }
        public AppointmentDetailsResource Appointment { get; set; }
    }
}