using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HealthPlusPlus_AW.meeting.Domain.Models;
using HealthPlusPlus_AW.meeting.Domain.Services;
using HealthPlusPlus_AW.meeting.Resource;
using HealthPlusPlus_AW.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HealthPlusPlus_AW.meeting.Controllers
{
    [Route("/api/v1/[controller]")]
    public class AppointmentDetailsController : ControllerBase
    {
        private readonly IAppointmentDetailsService _appointmentDetailsService;
        private readonly IMapper _mapper;

        public AppointmentDetailsController(IAppointmentDetailsService appointmentDetailsService, IMapper mapper)
        {
            _appointmentDetailsService = appointmentDetailsService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "Get All Appointment Details",
            Description = "Get All Appointment Details",
            OperationId = "GetAllAppointmentDetails")]
        [HttpGet]
        public async Task<IEnumerable<AppointmentDetailsResource>> GetAllAsync()
        {
            var medicalHistories = await _appointmentDetailsService.ListAsync();
            var resources = _mapper.Map<IEnumerable<AppointmentDetails>, IEnumerable<AppointmentDetailsResource>>(medicalHistories);
            return resources;
        }
        
        [SwaggerOperation(
            Summary = "Get Appointment Details By Id",
            Description = "Get Appointment Details By Id",
            OperationId = "GetAppointmentDetailsById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _appointmentDetailsService.FindIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var appointmentDetailsResource = _mapper.Map<AppointmentDetails, AppointmentDetailsResource>(result.Resource);
            return Ok(appointmentDetailsResource);    
        }

        [SwaggerOperation(
            Summary = "Get Appointment Details By Diagnostic Id",
            Description = "Get Appointment Details By Diagnostic Id",
            OperationId = "GetAppointmentDetailsByDiagnosticId")]
        [HttpGet("/appointmentDetails/diagnostic/{id}")]
        public async Task<IEnumerable<AppointmentDetailsResource>> GetByDiagnosticIdAsync(int id)
        {
            var appointmentDetails = await _appointmentDetailsService.ListByDiagnosticIdAsync(id);
            var resources = _mapper.Map<IEnumerable<AppointmentDetails>, IEnumerable<AppointmentDetailsResource>>(appointmentDetails);
            return resources; 
        }
        
        [SwaggerOperation(
            Summary = "Create an Appointment Details",
            Description = "Create a Appointment Details",
            OperationId = "CreateAnAppointmentDetails")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAppointmentDetailsResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var appointmentDetails = _mapper.Map<SaveAppointmentDetailsResource, AppointmentDetails>(resource);
            var result = await _appointmentDetailsService.SaveAsync(appointmentDetails);
            if (!result.Success)
                return BadRequest(result.Message);

            var appointmentDetailsResource = _mapper.Map<AppointmentDetails, AppointmentDetailsResource>(result.Resource);
            return Ok(appointmentDetailsResource);
        }
        
        [SwaggerOperation(
            Summary = "Update an Appointment Details",
            Description = "Update a Appointment Details",
            OperationId = "UpdateAnAppointmentDetails")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAppointmentDetailsResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var appointmentDetails = _mapper.Map<SaveAppointmentDetailsResource, AppointmentDetails>(resource);
            var result = await _appointmentDetailsService.UpdateAsync(id, appointmentDetails);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var appointmentResource = _mapper.Map<AppointmentDetails, AppointmentResource>(result.Resource);
            return Ok(appointmentResource);
        }
        
        [SwaggerOperation(
            Summary = "Delete an Appointment Details",
            Description = "Delete a Appointment Details",
            OperationId = "DeleteAnAppointmentDetails")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) {
            var result = await _appointmentDetailsService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var appointmentDetailsResource = _mapper.Map<AppointmentDetails, AppointmentDetailsResource>(result.Resource);
            return Ok(appointmentDetailsResource); 
        }
    }
}