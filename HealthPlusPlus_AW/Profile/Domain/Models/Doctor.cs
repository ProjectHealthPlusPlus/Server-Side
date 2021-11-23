using System.Collections.Generic;
using HealthPlusPlus_AW.Heal.Domain.Models;
using HealthPlusPlus_AW.meeting.Domain.Models;
using HealthPlusPlus_AW.Profile.Domain.Repositories;

namespace HealthPlusPlus_AW.Profile.Domain.Models
{
    public class Doctor : User
    {
        //RelationShips
        public int SpecialtyId;
        public Specialty Specialty;
        public int ClinicId;
        public Clinic Clinic;
        
        public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}