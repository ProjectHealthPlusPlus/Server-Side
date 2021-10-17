using System;

namespace HealthPlusPlus_AW.Domain.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime StartAt { get; set; }
        
        public User User { get; set; }
        public Doctor Doctor { get; set; }
        public AppointmentDetails AppointmentDetails { get; set; }
    }
}