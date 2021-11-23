using HealthPlusPlus_AW.Profile.Resource;

namespace HealthPlusPlus_AW.Heal.Resource
{
    public class MedicalHistoryResource
    {
        public int Id { get; set; }
        
        public PatientResource Patient { get; set; }
        public ClinicResource Clinic { get; set; }
        //
        // public IList<DiagnosticResource> Diagnostics { get; set; } = new List<DiagnosticResource>();

    }
}