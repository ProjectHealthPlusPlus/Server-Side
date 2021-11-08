﻿using System.ComponentModel.DataAnnotations;

namespace HealthPlusPlus_AW.Resources
{
    public class SaveClinicLocationResource
    {
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string CapitalCity { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
    }
}