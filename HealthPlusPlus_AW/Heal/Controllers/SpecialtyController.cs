using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HealthPlusPlus_AW.Heal.Domain.Models;
using HealthPlusPlus_AW.Heal.Domain.Services;
using HealthPlusPlus_AW.Heal.Resource;
using HealthPlusPlus_AW.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlusPlus_AW.Heal.Controllers
{
    [Route("/api/v1/[controller]")]
    public class SpecialtyController : ControllerBase
    {
        private readonly ISpecialtyService _specialtyService;
        private readonly IMapper _mapper;

        public SpecialtyController(ISpecialtyService specialtyService, IMapper mapper)
        {
            _specialtyService = specialtyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SpecialtyResource>> GetAllAsync()
        {
            var specialties = await _specialtyService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Specialty>, IEnumerable<SpecialtyResource>>(specialties);
            return resources;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _specialtyService.FindIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var specialtyResource = _mapper.Map<Specialty, SpecialtyResource>(result.Resource);
            return Ok(specialtyResource);    
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSpecialtyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var specialty = _mapper.Map<SaveSpecialtyResource, Specialty>(resource);
            var result = await _specialtyService.SaveAsync(specialty);
            if (!result.Success)
                return BadRequest(result.Message);

            var specialtyResource = _mapper.Map<Specialty, SpecialtyResource>(result.Resource);
            return Ok(specialtyResource);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSpecialtyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var specialty = _mapper.Map<SaveSpecialtyResource, Specialty>(resource);
            var result = await _specialtyService.UpdateAsync(id, specialty);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var categoryResource = _mapper.Map<Specialty, SpecialtyResource>(result.Resource);
            return Ok(categoryResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) {
            var result = await _specialtyService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var specialtyResource = _mapper.Map<Specialty, SpecialtyResource>(result.Resource);
            return Ok(specialtyResource);    
        }
    }
}