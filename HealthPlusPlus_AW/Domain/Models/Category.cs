using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthPlusPlus_AW.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        //Relationships
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}