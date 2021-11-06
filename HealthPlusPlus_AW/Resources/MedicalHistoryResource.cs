using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;

namespace HealthPlusPlus_AW.Resources
{
    [SwaggerSchema(Required = new [] {"Description"})]
    public class MedicalHistoryResource
    {
        [SwaggerSchema("Medical History Identifier")]
        public int Id { get; set; }
        
        public PatientResource PatientResource { get; set; }
        public ClinicResource ClinicResource { get; set; }
    }
}