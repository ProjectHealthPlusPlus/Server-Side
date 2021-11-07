using System;
using System.Collections.Generic;

namespace HealthPlusPlus_AW.Domain.Models
{
    public class AppointmentDetails
    {
        public int Id { get; set; }
        public DateTime UserStartAt { get; set; }
        public DateTime DoctorStartAt { get; set; }
        public DateTime UserEndAt { get; set; }
        public DateTime DoctorEndAt { get; set; }
        
        //RelationShips
        public int DiagnosticId { get; set; }
        public Diagnostic Diagnostic { get; set; }
        public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}