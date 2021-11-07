using System.Collections.Generic;

namespace HealthPlusPlus_AW.Domain.Models
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