using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;

namespace HealthPlusPlus_AW.Resources
{
    [SwaggerSchema(Required = new [] {"Description"})]
    public class PatientResource : UserResource
    {
        [SwaggerSchema("Patient Identifier")]
        public string Address { get; set; }
    }
}