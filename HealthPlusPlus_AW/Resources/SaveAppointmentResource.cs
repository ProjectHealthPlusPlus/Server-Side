using System;

namespace HealthPlusPlus_AW.Resources
{
    public class SaveAppointmentResource
    {
        public int Id { get; set; }
        public DateTime StartAt { get; set; }
        
        public UserResource UserResource { get; set; }
        public DoctorResource DoctorResource { get; set; }
        public AppointmentDetailsResource AppointmentDetailsResource { get; set; }
    }
}