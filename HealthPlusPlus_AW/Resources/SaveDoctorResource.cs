using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthPlusPlus_AW.Resources
{
    public class SaveDoctorResource : SaveUserResource
    {
        [Required]
        public int SpecialtyId { get; set; }  
        
        [Required]
        public int ClinicId { get; set; }  
    }
}