using System.Collections.Generic;

namespace HealthPlusPlus_AW.Resources
{
    public class MedicalHistoryResource
    {
        public int Id { get; set; }
        
        public PatientResource Patient { get; set; }
        public ClinicResource Clinic { get; set; }
        public IList<DiagnosticResource> Diagnostics { get; set; } = new List<DiagnosticResource>();

    }
}