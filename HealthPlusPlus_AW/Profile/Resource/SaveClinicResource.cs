using System.ComponentModel.DataAnnotations;

namespace HealthPlusPlus_AW.Profile.Resource
{
    public class SaveClinicResource : UserResource
    {
        [Required]
        public int ClinicLocationId { get; set; }    
    }
}