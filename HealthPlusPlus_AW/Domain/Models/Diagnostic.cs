using System;

namespace HealthPlusPlus_AW.Domain.Models
{
    public class Diagnostic
    {
        public int Id { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        
        public Specialty Specialty { get; set; }
    }
}