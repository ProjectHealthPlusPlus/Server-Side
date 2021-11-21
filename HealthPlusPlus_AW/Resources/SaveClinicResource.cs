using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthPlusPlus_AW.Resources
{
    public class SaveClinicResource : SaveUserResource
    {
        [Required]
        [MaxLength(50)]
        public int ClinicLocationId { get; set; }    
    }
}