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
    public class ClinicController : ControllerBase
    {
        private readonly IClinicService _clinicService;
        private readonly IMapper _mapper;

        public ClinicController(IClinicService medicalHistoryService, IMapper mapper)
        {
            _clinicService = medicalHistoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ClinicResource>> GetAllAsync()
        {
            var clinics = await _clinicService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Clinic>, IEnumerable<ClinicResource>>(clinics);
            return resources;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _clinicService.FindIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var clinicResource = _mapper.Map<Clinic, ClinicResource>(result.Clinic);
            return Ok(clinicResource);    
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveMedicalHistoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var clinic = _mapper.Map<SaveMedicalHistoryResource, Clinic>(resource);
            var result = await _clinicService.SaveAsync(clinic);
            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Clinic, ClinicResource>(result.Clinic);
            return Ok(categoryResource);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveClinicResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var clinic = _mapper.Map<SaveClinicResource, Clinic>(resource);
            var result = await _clinicService.UpdateAsync(id, clinic);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var clinicResource = _mapper.Map<Clinic, SaveMedicalHistoryResource>(result.Clinic);
            return Ok(clinicResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) {
            var result = await _clinicService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var clinicResource = _mapper.Map<Clinic, ClinicResource>(result.Clinic);
            return Ok(clinicResource);    
        }
    }
}