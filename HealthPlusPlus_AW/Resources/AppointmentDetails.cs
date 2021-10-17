using System;

namespace HealthPlusPlus_AW.Resources
{
    public class AppointmentDetails
    {
        public int Id { get; set; }
        public DateTime UserStartAt { get; set; }
        public DateTime DoctorStartAt { get; set; }
        public DateTime UserEndAt { get; set; }
        public DateTime DoctorEndAt { get; set; }
        
        public Diagnostic Diagnostic { get; set; }
    }
}