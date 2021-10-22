using System.Collections.Generic;

namespace HealthPlusPlus_AW.Resources
{
    public class SaveMedicalHistoryResource
    {
        public int Id { get; set; }
        
        public PatientResource PatientResource { get; set; }
        public ClinicResource ClinicResource { get; set; }
        public IList<DiagnosticResource> Diagnostics { get; set; } = new List<DiagnosticResource>();
    }
}