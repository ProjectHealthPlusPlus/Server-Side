using System;
using System.ComponentModel.DataAnnotations;

namespace HealthPlusPlus_AW.Resources
{
    public class SaveAppointmentResource
    {
        [Required]
        [MaxLength(30)]
        public DateTime StartAt { get; set; }
        
        [Required]
        [MaxLength(30)]
        public int UserId { get; set; }  
        [Required]
        [MaxLength(30)]
        public int DoctorId { get; set; }  
        [Required]
        [MaxLength(30)]
        public int AppointmentDetailsId { get; set; }  

    }
}