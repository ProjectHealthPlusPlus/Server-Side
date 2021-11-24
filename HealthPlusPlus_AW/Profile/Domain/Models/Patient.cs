using System.Collections.Generic;
using HealthPlusPlus_AW.Heal.Domain.Models;
using HealthPlusPlus_AW.meeting.Domain.Models;
using HealthPlusPlus_AW.Profile.Domain.Repositories;

namespace HealthPlusPlus_AW.Profile.Domain.Models
{
    public class Patient : User
    {
        public string Address { get; set; }
        public IList<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();
        
        public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}