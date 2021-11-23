using Swashbuckle.AspNetCore.Annotations;

namespace HealthPlusPlus_AW.Profile.Resource
{
    [SwaggerSchema(Required = new [] {"Description"})]
    public class PatientResource : UserResource
    {
        [SwaggerSchema("Patient Identifier")]
        public string Address { get; set; }
    }
}