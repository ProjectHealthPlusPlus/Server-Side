﻿using System.Collections.Generic;

namespace HealthPlusPlus_AW.Example.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        //Relationships
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}