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
        
        public UserResource UserResource { get; set; }
        public DoctorResource DoctorResource { get; set; }
        public AppointmentDetailsResource AppointmentDetailsResource { get; set; }
    }
}