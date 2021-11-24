using System.ComponentModel.DataAnnotations;

namespace HealthPlusPlus_AW.Profile.Resource
{
    public class SaveDoctorResource : SaveUserResource
    {
        [Required]
        public int SpecialtyId { get; set; }  
        
        [Required]
        public int ClinicId { get; set; }  
    }
}