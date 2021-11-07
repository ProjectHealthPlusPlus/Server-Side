using System.ComponentModel.DataAnnotations;

namespace HealthPlusPlus_AW.Resources
{
    public class SaveProductResource
    {   
        [Required]
        [MaxLength(50)]
        public string Name;
        
        [Required]
        [Range(0,100)]
        public short QuantityInPackage { get; set; }
        
        [Required]
        [Range(1,5)]
        public short UnitOfMeasurement { get; set; }
        
        [Required]
        public int CategoryId { get; set; }    
    }
}