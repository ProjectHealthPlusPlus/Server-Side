using System;
using Swashbuckle.AspNetCore.Annotations;

namespace HealthPlusPlus_AW.Resources
{
    [SwaggerSchema(Required = new [] {"Description"})]
    public class AppointmentResource
    {
        [SwaggerSchema("Appointment Identifier")]
        public int Id { get; set; }
        
        [SwaggerSchema("Appointment StartAt Time")]
        public DateTime StartAt { get; set; }
        
        public UserResource User { get; set; }
        public DoctorResource Doctor { get; set; }
        public AppointmentDetailsResource Appointment { get; set; }
    }
}