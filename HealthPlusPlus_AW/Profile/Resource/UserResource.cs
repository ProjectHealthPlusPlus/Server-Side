using Swashbuckle.AspNetCore.Annotations;

namespace HealthPlusPlus_AW.Profile.Resource
{
    [SwaggerSchema(Required = new [] {"Description"})]
    public class UserResource
    {
        [SwaggerSchema("User Identifier")]
        public int Id { get; set; } 
        [SwaggerSchema("User Dni")]
        public string Dni { get; set; } 
        [SwaggerSchema("User Name")]
        public string Name { get; set; } 
        [SwaggerSchema("User Lastname")]
        public string Lastname { get; set; }
        [SwaggerSchema("User Age")]
        public int Age { get; set; }
    }
}