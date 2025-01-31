﻿using System;
using HealthPlusPlus_AW.Profile.Resource;
using Swashbuckle.AspNetCore.Annotations;

namespace HealthPlusPlus_AW.meeting.Resource
{
    [SwaggerSchema(Required = new [] {"Description"})]
    public class AppointmentResource
    {
        [SwaggerSchema("Appointment Identifier")]
        public int Id { get; set; }
        
        [SwaggerSchema("Appointment StartAt Time")]
        public DateTime StartAt { get; set; }
        
        public AppointmentDetailsResource AppointmentDetails { get; set; }
        
        public PatientResource Patient { get; set; }
        public DoctorResource Doctor { get; set; }
        
    }
}