using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HealthPlusPlus_AW.Heal.Resource;
using HealthPlusPlus_AW.Profile.Domain.Models;
using HealthPlusPlus_AW.Profile.Domain.Services;
using HealthPlusPlus_AW.Profile.Resource;
using HealthPlusPlus_AW.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HealthPlusPlus_AW.Profile.Controllers
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

        [SwaggerOperation(
            Summary = "Get All Claim Clinics",
            Description = "Get All Clinics",
            OperationId = "GetAllClinics")]
        [HttpGet]
        public async Task<IEnumerable<ClinicResource>> GetAllAsync()
        {
            var clinics = await _clinicService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Clinic>, IEnumerable<ClinicResource>>(clinics);
            return resources;
        }
        
        [SwaggerOperation(
            Summary = "Get Clinic By Id",
            Description = "Get Clinic By Id",
            OperationId = "GetClinicById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _clinicService.FindIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var clinicResource = _mapper.Map<Clinic, ClinicResource>(result.Resource);
            return Ok(clinicResource);    
        }
        
        [SwaggerOperation(
            Summary = "Get Clinic By Clinic Location Id",
            Description = "Get Clinic By Clinic Location Id",
            OperationId = "GetClinicByClinicLocationId")]
        [HttpGet("/clinic/clinicLocation/{id}")]
        public async Task<IEnumerable<ClinicResource>> GetClinicByClinicLocationIdAsync(int id)
        {
            var products = await _clinicService.ListByClinicLocationIdAsync(id);
            var resources = _mapper.Map<IEnumerable<Clinic>, IEnumerable<ClinicResource>>(products);
            return resources;
        }
        
        [SwaggerOperation(
            Summary = "Create a Clinic",
            Description = "Create a Clinic",
            OperationId = "CreateAClinic")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveMedicalHistoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var clinic = _mapper.Map<SaveMedicalHistoryResource, Clinic>(resource);
            var result = await _clinicService.SaveAsync(clinic);
            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Clinic, ClinicResource>(result.Resource);
            return Ok(categoryResource);
        }
        
        [SwaggerOperation(
            Summary = "Update a Clinic",
            Description = "Update a Clinic",
            OperationId = "UpdateAClinic")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveClinicResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var clinic = _mapper.Map<SaveClinicResource, Clinic>(resource);
            var result = await _clinicService.UpdateAsync(id, clinic);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var clinicResource = _mapper.Map<Clinic, SaveMedicalHistoryResource>(result.Resource);
            return Ok(clinicResource);
        }
        
        [SwaggerOperation(
            Summary = "Delete a Clinic",
            Description = "Delete a Clinic",
            OperationId = "DeleteAClinic")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) {
            var result = await _clinicService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var clinicResource = _mapper.Map<Clinic, ClinicResource>(result.Resource);
            return Ok(clinicResource);    
        }
    }
}