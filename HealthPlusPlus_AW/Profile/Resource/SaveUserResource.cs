using System.ComponentModel.DataAnnotations;

namespace HealthPlusPlus_AW.Profile.Resource
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(8)]
        public string Dni { get; set; } 
        
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } 
        
        [Required]
        [MaxLength(30)]
        public string Lastname { get; set; } 
        
        [Required]
        public int Age { get; set; } 
    }
}