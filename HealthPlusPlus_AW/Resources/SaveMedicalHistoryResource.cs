using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthPlusPlus_AW.Resources
{
    public class SaveMedicalHistoryResource
    {
        [Required]
        public int PatientId { get; set; }    
        [Required]
        public int ClinicId { get; set; }
    }
}