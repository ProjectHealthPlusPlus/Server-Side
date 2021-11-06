using System;
using System.ComponentModel.DataAnnotations;

namespace HealthPlusPlus_AW.Resources
{
    public class SaveAppointmentResource
    {
        public int Id { get; set; }
        public DateTime StartAt { get; set; }
        
        [Required]
        public int UserId { get; set; }  
        [Required]
        public int DoctorId { get; set; }  
        [Required]
        public int AppointmentDetailsId { get; set; }  

    }
}