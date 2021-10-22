using System;

namespace HealthPlusPlus_AW.Resources
{
    public class SaveAppointmentDetailsResource
    {
        public int Id { get; set; }
        public DateTime UserStartAt { get; set; }
        public DateTime DoctorStartAt { get; set; }
        public DateTime UserEndAt { get; set; }
        public DateTime DoctorEndAt { get; set; }
        
        public DiagnosticResource DiagnosticResource { get; set; }
    }
}