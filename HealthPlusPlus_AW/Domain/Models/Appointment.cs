using System;

namespace HealthPlusPlus_AW.Domain.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime StartAt { get; set; }
        //RelationShips
        public int AppointmentDetailsId { get; set; }
        public AppointmentDetails AppointmentDetails { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}