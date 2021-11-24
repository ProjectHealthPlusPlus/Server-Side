using System.ComponentModel.DataAnnotations;

namespace HealthPlusPlus_AW.Heal.Resource
{
    public class SaveMedicalHistoryResource
    {
        [Required]
        public int PatientId { get; set; }    
        [Required]
        public int ClinicId { get; set; }
    }
}