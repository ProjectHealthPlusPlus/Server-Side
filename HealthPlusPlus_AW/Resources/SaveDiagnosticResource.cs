using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HealthPlusPlus_AW.Resources
{
    public class SaveDiagnosticResource
    {
        [Required]
        [MaxLength(30)]
        public DateTime PublishDate { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Description { get; set; }
        
        [Required]
        public int SpecialtyId { get; set; }
    }
}