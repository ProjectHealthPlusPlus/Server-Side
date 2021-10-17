using System.Collections.Generic;

namespace HealthPlusPlus_AW.Domain.Models
{
    public class MedicalHistory
    {
        public int Id { get; set; }
        
        public Patient Patient { get; set; }
        public Clinic Clinic { get; set; }
        public IList<Diagnostic> Diagnostics { get; set; } = new List<Diagnostic>();
    }
}