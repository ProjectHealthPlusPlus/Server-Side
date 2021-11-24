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
    public class ClinicLocationController : ControllerBase
    {
        private readonly IClinicLocationService _clinicLocationService;
        private readonly IMapper _mapper;

        public ClinicLocationController(IClinicLocationService clinicLocationService, IMapper mapper)
        {
            _clinicLocationService = clinicLocationService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "Get All Claim Clinic Locations",
            Description = "Get All Clinic Locations",
            OperationId = "GetAllClinicLocations")]
        [HttpGet]
        public async Task<IEnumerable<ClinicLocationResource>> GetAllAsync()
        {
            var medicalHistories = await _clinicLocationService.ListAsync();
            var resources = _mapper.Map<IEnumerable<ClinicLocation>, IEnumerable<ClinicLocationResource>>(medicalHistories);
            return resources;
        }
        
        [SwaggerOperation(
            Summary = "Get a Clinic Location  By Id",
            Description = "Get a Clinic Location By Id",
            OperationId = "GetAClinic LocationById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _clinicLocationService.FindIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var clinicLocationResource = _mapper.Map<ClinicLocation, ClinicLocationResource>(result.Resource);
            return Ok(clinicLocationResource);    
        }
        
        [SwaggerOperation(
            Summary = "Create a Clinic Location",
            Description = "Create a Clinic Location",
            OperationId = "CreateAClinic Location")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveClinicLocationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var medicalHistory = _mapper.Map<SaveClinicLocationResource, ClinicLocation>(resource);
            var result = await _clinicLocationService.SaveAsync(medicalHistory);
            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<ClinicLocation, ClinicLocationResource>(result.Resource);
            return Ok(categoryResource);
        }
        
        [SwaggerOperation(
            Summary = "Update a Clinic Location",
            Description = "Update a Clinic Location",
            OperationId = "UpdateAClinic Location")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveClinicLocationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var clinicLocation = _mapper.Map<SaveClinicLocationResource, ClinicLocation>(resource);
            var result = await _clinicLocationService.UpdateAsync(id, clinicLocation);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var medicalHistoryResource = _mapper.Map<ClinicLocation, ClinicLocationResource>(result.Resource);
            return Ok(medicalHistoryResource);
        }
        
        [SwaggerOperation(
            Summary = "Delete a Clinic Location",
            Description = "Delete a Clinic Location",
            OperationId = "DeleteAClinicLocation")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) {
            var result = await _clinicLocationService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var clinicLocationResource = _mapper.Map<ClinicLocation, ClinicLocationResource>(result.Resource);
            return Ok(clinicLocationResource);    
        }
    }
}