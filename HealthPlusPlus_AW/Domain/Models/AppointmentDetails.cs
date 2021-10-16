using System;

namespace HealthPlusPlus_AW.Domain.Models
{
    public class AppointmentDetails
    {
        public int id { get; set; }
        public DateTime UserStartAt { get; set; }
        public DateTime DoctorStartAt { get; set; }
        public DateTime UserEndAt { get; set; }
        public DateTime DoctorEndAt { get; set; }
        
        public Diagnostic Diagnostic { get; set; }
    }
}