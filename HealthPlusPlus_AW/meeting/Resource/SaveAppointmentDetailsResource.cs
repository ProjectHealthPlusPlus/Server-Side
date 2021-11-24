using System;
using System.ComponentModel.DataAnnotations;

namespace HealthPlusPlus_AW.meeting.Resource
{
    public class SaveAppointmentDetailsResource
    {
        [Required]
        [MaxLength(50)]
        public DateTime UserStartAt { get; set; }
        
        [Required]
        [MaxLength(50)]
        public DateTime DoctorStartAt { get; set; }
        
        [Required]
        [MaxLength(50)]
        public DateTime UserEndAt { get; set; }
        
        [Required]
        [MaxLength(50)]
        public DateTime DoctorEndAt { get; set; }
        
        [Required]
        public int DiagnosticId { get; set; }
    }
}