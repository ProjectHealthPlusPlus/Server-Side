﻿using System.ComponentModel.DataAnnotations;

namespace HealthPlusPlus_AW.Example.Resources
{
    public class SaveCategoryResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}