using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Extensions;
using HealthPlusPlus_AW.Resources;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlusPlus_AW.Controllers
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

        [HttpGet]
        public async Task<IEnumerable<AppointmentResource>> GetAllAsync()
        {
            var appointments = await _appointmentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentResource>>(appointments);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _appointmentService.FindIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Appointment);
            return Ok(appointmentResource);    
        }

        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAppointmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var appointment = _mapper.Map<SaveAppointmentResource, Appointment>(resource);
            var result = await _appointmentService.SaveAsync(appointment);
            if (!result.Success)
                return BadRequest(result.Message);

            var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Appointment);
            return Ok(appointmentResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAppointmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var appointment = _mapper.Map<SaveAppointmentResource, Appointment>(resource);
            var result = await _appointmentService.UpdateAsync(id, appointment);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Appointment);
            return Ok(appointmentResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) {
            var result = await _appointmentService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Appointment);
            return Ok(appointmentResource);    
        }
    }
}