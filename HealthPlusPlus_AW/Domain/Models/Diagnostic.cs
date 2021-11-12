using System;
using System.Collections.Generic;

namespace HealthPlusPlus_AW.Domain.Models
{
    public class Diagnostic
    {
        public int Id { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        
        //RelationShips
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }
        public int MedicalHistoryId { get; set; }
        public MedicalHistory MedicalHistory { get; set; }
        public IList<AppointmentDetails> AppointmentDetails { get; set; } = new List<AppointmentDetails>();

    }
}