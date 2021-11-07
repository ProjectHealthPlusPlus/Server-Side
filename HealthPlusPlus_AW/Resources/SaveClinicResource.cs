using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthPlusPlus_AW.Resources
{
    public class SaveClinicResource : UserResource
    {
        [Required]
        public int ClinicLocationId { get; set; }    
    }
}