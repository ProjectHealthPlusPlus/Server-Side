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
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "Get All Claim Appointments",
            Description = "Get All Appointments",
            OperationId = "GetAllAppointments")]
        [HttpGet]
        public async Task<IEnumerable<AppointmentResource>> GetAllAsync()
        {
            var appointments = await _appointmentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentResource>>(appointments);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Get Appointment By Id",
            Description = "Get Appointment By Id",
            OperationId = "GetAppointmentById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _appointmentService.FindIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Resource);
            return Ok(appointmentResource);    
        }

        [SwaggerOperation(
            Summary = "Get Appointments By Appointment Details Id",
            Description = "Get Appointments By Appointment Details Id",
            OperationId = "GetAppointmentsByAppointmentDetailsId")]
        [HttpGet("/appointment/appointmentDetails/{id}")]
        public async Task<IEnumerable<AppointmentResource>> GetAppointmentByAppointmentDetailsIdAsync(int id)
        {
            var appointmentDetails = await _appointmentService.ListByAppointmentDetailsIdAsync(id);
            var resources = _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentResource>>(appointmentDetails);
            return resources;
        }
        
        [SwaggerOperation(
            Summary = "Get Appointments By Patient Id",
            Description = "Get Appointments By Patient Id",
            OperationId = "GetAppointmentsByPatientId")]
        [HttpGet("/appointment/patient/{id}")]
        public async Task<IEnumerable<AppointmentResource>> GetAppointmentByPatientIdAsync(int id)
        {
            var patients = await _appointmentService.ListByPatientIdAsync(id);
            var resources = _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentResource>>(patients);
            return resources;
        }
        
        [SwaggerOperation(
            Summary = "Get Appointments By Doctor Id",
            Description = "Get Appointments By Doctor Id",
            OperationId = "GetAppointmentsByDoctorId")]
        [HttpGet("/appointment/doctor/{id}")]
        public async Task<IEnumerable<AppointmentResource>> GetAppointmentByDoctorIdAsync(int id)
        {
            var doctors = await _appointmentService.ListByDoctorIdAsync(id);
            var resources = _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentResource>>(doctors);
            return resources;
        }
        
        [SwaggerOperation(
            Summary = "Create an Appointment",
            Description = "Create an Appointment",
            OperationId = "CreateAnAppointment")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAppointmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var appointment = _mapper.Map<SaveAppointmentResource, Appointment>(resource);
            var result = await _appointmentService.SaveAsync(appointment);
            if (!result.Success)
                return BadRequest(result.Message);

            var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Resource);
            return Ok(appointmentResource);
        }

        [SwaggerOperation(
            Summary = "Update an Appointment",
            Description = "Update an Appointment",
            OperationId = "UpdateAnAppointment")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAppointmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var appointment = _mapper.Map<SaveAppointmentResource, Appointment>(resource);
            var result = await _appointmentService.UpdateAsync(id, appointment);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Resource);
            return Ok(appointmentResource);
        }
        
        [SwaggerOperation(
            Summary = "Delete an Appointment",
            Description = "Delete an Appointment",
            OperationId = "DeleteAnAppointment")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) {
            var result = await _appointmentService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Resource);
            return Ok(appointmentResource);    
        }
    }
}