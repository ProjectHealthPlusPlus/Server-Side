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
    public class ClinicLocationController : ControllerBase
    {
        private readonly IClinicLocationService _clinicLocationService;
        private readonly IMapper _mapper;

        public ClinicLocationController(IClinicLocationService clinicLocationService, IMapper mapper)
        {
            _clinicLocationService = clinicLocationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ClinicLocationResource>> GetAllAsync()
        {
            var medicalHistories = await _clinicLocationService.ListAsync();
            var resources = _mapper.Map<IEnumerable<ClinicLocation>, IEnumerable<ClinicLocationResource>>(medicalHistories);
            return resources;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _clinicLocationService.FindIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var clinicLocationResource = _mapper.Map<ClinicLocation, ClinicLocationResource>(result.ClinicLocation);
            return Ok(clinicLocationResource);    
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveClinicLocationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var medicalHistory = _mapper.Map<SaveClinicLocationResource, ClinicLocation>(resource);
            var result = await _clinicLocationService.SaveAsync(medicalHistory);
            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<ClinicLocation, ClinicLocationResource>(result.ClinicLocation);
            return Ok(categoryResource);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveClinicLocationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var clinicLocation = _mapper.Map<SaveClinicLocationResource, ClinicLocation>(resource);
            var result = await _clinicLocationService.UpdateAsync(id, clinicLocation);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var medicalHistoryResource = _mapper.Map<ClinicLocation, ClinicLocationResource>(result.ClinicLocation);
            return Ok(medicalHistoryResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) {
            var result = await _clinicLocationService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var clinicLocationResource = _mapper.Map<ClinicLocation, ClinicLocationResource>(result.ClinicLocation);
            return Ok(clinicLocationResource);    
        }
    }
}