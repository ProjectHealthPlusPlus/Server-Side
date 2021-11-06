using System.Collections.Generic;

namespace HealthPlusPlus_AW.Domain.Models
{
    public class Patient : User
    {
        public string Address { get; set; }
        public IList<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();
        
        public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}