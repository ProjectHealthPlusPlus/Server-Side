using Swashbuckle.AspNetCore.Annotations;

namespace HealthPlusPlus_AW.meeting.Resource
{
    [SwaggerSchema(Required = new [] {"Description"})]
    public class ClinicLocationResource
    {
        [SwaggerSchema("Clinic Location Identifier")]
        public int Id { get; set; }
        [SwaggerSchema("Clinic Address Location")]
        public string Address { get; set; }
        [SwaggerSchema("Clinic Capital City Location")]
        public string CapitalCity { get; set; }
        [SwaggerSchema("Clinic Country Location")]
        public string Country { get; set; }
    }
}