using System;
using Swashbuckle.AspNetCore.Annotations;

namespace HealthPlusPlus_AW.Heal.Resource
{
    [SwaggerSchema(Required = new [] {"Description"})]
    public class DiagnosticResource
    {
        [SwaggerSchema("Diagnostic Identifier")]
        public int Id { get; set; }
        [SwaggerSchema("Diagnostic Publish Date")]
        public DateTime PublishDate { get; set; }
        [SwaggerSchema("Diagnostic Description")]
        public string Description { get; set; }
        
        public SpecialtyResource Specialty { get; set; }
        public MedicalHistoryResource MedicalHistory { get; set; }
    }
}