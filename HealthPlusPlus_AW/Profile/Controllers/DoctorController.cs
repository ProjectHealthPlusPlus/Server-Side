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
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "Get All Doctor",
            Description = "Get All Doctor",
            OperationId = "GetAllDoctor")]
        [HttpGet]
        public async Task<IEnumerable<DoctorResource>> GetAllAsync()
        {
            var doctors = await _doctorService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorResource>>(doctors);
            return resources;
        }
        
        [SwaggerOperation(
            Summary = "Get Doctor By Id",
            Description = "Get Doctor By Id",
            OperationId = "GetDoctorById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _doctorService.FindIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var doctorResource = _mapper.Map<Doctor, DoctorResource>(result.Resource);
            return Ok(doctorResource);    
        }
        
        [SwaggerOperation(
            Summary = "Get Doctor By Clinic Specialty Id",
            Description = "Get Doctor By Clinic Specialty Id",
            OperationId = "GetDoctorBySpecialtyId")]
        [HttpGet("/doctor/specialty/{id}")]
        public async Task<IEnumerable<DoctorResource>> GetDoctorBySpecialtyIdAsync(int id)
        {
            var doctors = await _doctorService.ListBySpecialtyIdAsync(id);
            var resources = _mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorResource>>(doctors);
            return resources;
        }
        
        [SwaggerOperation(
            Summary = "Get Doctor By Clinic Clinic Id",
            Description = "Get Doctor By Clinic Location Id",
            OperationId = "GetDoctorByClinicClinicId")]
        [HttpGet("/doctor/clinic/{id}")]
        public async Task<IEnumerable<DoctorResource>> GetDoctorByClinicIdAsync(int id)
        {
            var doctors = await _doctorService.ListByClinicIdAsync(id);
            var resources = _mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorResource>>(doctors);
            return resources;
        }
        
        [SwaggerOperation(
            Summary = "Create a Doctor",
            Description = "Create a Doctor",
            OperationId = "CreateADoctor")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDoctorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var doctor = _mapper.Map<SaveDoctorResource, Doctor>(resource);
            var result = await _doctorService.SaveAsync(doctor);
            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Doctor, DoctorResource>(result.Resource);
            return Ok(categoryResource);
        }
        
        [SwaggerOperation(
            Summary = "Update a Doctor",
            Description = "Update a Doctor",
            OperationId = "UpdateADoctor")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDoctorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var doctor = _mapper.Map<SaveDoctorResource, Doctor>(resource);
            var result = await _doctorService.UpdateAsync(id, doctor);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var categoryResource = _mapper.Map<Doctor, DoctorResource>(result.Resource);
            return Ok(categoryResource);
        }
        
        [SwaggerOperation(
            Summary = "Delete a Doctor",
            Description = "Delete a Doctor",
            OperationId = "DeleteADoctor")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) {
            var result = await _doctorService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var doctorResource = _mapper.Map<Doctor, DoctorResource>(result.Resource);
            return Ok(doctorResource);    
        }
    }
}