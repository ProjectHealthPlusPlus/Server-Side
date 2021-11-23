using Swashbuckle.AspNetCore.Annotations;

namespace HealthPlusPlus_AW.Heal.Resource
{
    [SwaggerSchema(Required = new [] {"Description"})]
    public class SpecialtyResource
    {
        [SwaggerSchema("Specialty Identifier")]
        public int Id { get; set; }
        [SwaggerSchema("Specialty Name")]
        public string Name { get; set; }
        [SwaggerSchema("Specialty Description")]
        public string Description { get; set; }
    }
}