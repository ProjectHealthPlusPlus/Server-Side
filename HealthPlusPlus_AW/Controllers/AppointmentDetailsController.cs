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
    public class AppointmentDetailsController : ControllerBase
    {
        private readonly IAppointmentDetailsService _appointmentDetailsService;
        private readonly IMapper _mapper;

        public AppointmentDetailsController(IAppointmentDetailsService appointmentDetailsService, IMapper mapper)
        {
            _appointmentDetailsService = appointmentDetailsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AppointmentDetailsResource>> GetAllAsync()
        {
            var medicalHistories = await _appointmentDetailsService.ListAsync();
            var resources = _mapper.Map<IEnumerable<AppointmentDetails>, IEnumerable<AppointmentDetailsResource>>(medicalHistories);
            return resources;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _appointmentDetailsService.FindIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var appointmentDetailsResource = _mapper.Map<AppointmentDetails, AppointmentDetailsResource>(result.Resource);
            return Ok(appointmentDetailsResource);    
        }

        [HttpGet("/appointmentDetails/diagnostic/{id}")]
        public async Task<IEnumerable<AppointmentDetailsResource>> GetByDiagnosticIdAsync(int id)
        {
            var appointmentDetails = await _appointmentDetailsService.ListByDiagnosticIdAsync(id);
            var resources = _mapper.Map<IEnumerable<AppointmentDetails>, IEnumerable<AppointmentDetailsResource>>(appointmentDetails);
            return resources; 
        }
        
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