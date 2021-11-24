using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HealthPlusPlus_AW.Profile.Domain.Models;
using HealthPlusPlus_AW.Profile.Domain.Services;
using HealthPlusPlus_AW.Profile.Resource;
using HealthPlusPlus_AW.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HealthPlusPlus_AW.Profile.Controllers
{
    [Route("/api/v1/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public PatientController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "Get All Patient",
            Description = "Get All Patient",
            OperationId = "GetAllPatient")]
        [HttpGet]
        public async Task<IEnumerable<PatientResource>> GetAllAsync()
        {
            var patients = await _patientService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Patient>, IEnumerable<PatientResource>>(patients);
            return resources;
        }
        
        [SwaggerOperation(
            Summary = "Get Patient By Id",
            Description = "Get Patient By Id",
            OperationId = "GetPatientById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _patientService.FindIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var patientResource = _mapper.Map<Patient, PatientResource>(result.Resource);
            return Ok(patientResource);    
        }
        
        [SwaggerOperation(
            Summary = "Create a Patient",
            Description = "Create a Patient",
            OperationId = "CreateAPatient")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePatientResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var category = _mapper.Map<SavePatientResource, Patient>(resource);
            var result = await _patientService.SaveAsync(category);
            if (!result.Success)
                return BadRequest(result.Message);

            var patientResource = _mapper.Map<Patient, PatientResource>(result.Resource);
            return Ok(patientResource);
        }
        
        [SwaggerOperation(
            Summary = "Update a Patient",
            Description = "Update a Patient",
            OperationId = "UpdateAPatient")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePatientResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var patient = _mapper.Map<SavePatientResource, Patient>(resource);
            var result = await _patientService.UpdateAsync(id, patient);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var categoryResource = _mapper.Map<Patient, PatientResource>(result.Resource);
            return Ok(categoryResource);
        }
        
        [SwaggerOperation(
            Summary = "Delete a Patient",
            Description = "Delete a Patient",
            OperationId = "DeleteAPatient")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) {
            var result = await _patientService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var patientResource = _mapper.Map<Patient, PatientResource>(result.Resource);
            return Ok(patientResource);    
        }
    }
}