using System.ComponentModel.DataAnnotations;

namespace HealthPlusPlus_AW.Heal.Resource
{
    public class SaveSpecialtyResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } 
        
        [Required]
        [MaxLength(30)]
        public string Description { get; set; } 
    }
}