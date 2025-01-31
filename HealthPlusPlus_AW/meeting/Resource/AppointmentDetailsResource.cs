﻿using System;
using HealthPlusPlus_AW.Heal.Resource;
using Swashbuckle.AspNetCore.Annotations;

namespace HealthPlusPlus_AW.meeting.Resource
{
    [SwaggerSchema(Required = new [] {"Description"})]
    public class AppointmentDetailsResource
    {
        [SwaggerSchema("Appointment Details Identifier")]
        public int Id { get; set; }
        [SwaggerSchema("Appointment Details User StartAt Time")]
        public DateTime UserStartAt { get; set; }
        [SwaggerSchema("Appointment Details Doctor StartAt Time")]
        public DateTime DoctorStartAt { get; set; }
        [SwaggerSchema("Appointment Details User EndAt Time")]
        public DateTime UserEndAt { get; set; }
        [SwaggerSchema("Appointment Details Doctor EndAt Time")]
        public DateTime DoctorEndAt { get; set; }
        
        public DiagnosticResource Diagnostic { get; set; }
    }
}