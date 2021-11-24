using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HealthPlusPlus_AW.Heal.Domain.Models;
using HealthPlusPlus_AW.Heal.Domain.Services;
using HealthPlusPlus_AW.Heal.Resource;
using HealthPlusPlus_AW.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HealthPlusPlus_AW.Heal.Controllers
{
    [Route("/api/v1/[controller]")]
    public class DiagnosticController : ControllerBase
    {
        private readonly IDiagnosticService _diagnosticService;
        private readonly IMapper _mapper;

        public DiagnosticController(IDiagnosticService diagnosticService, IMapper mapper)
        {
            _diagnosticService = diagnosticService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "Get All Claim Diagnostics",
            Description = "Get All Diagnostics",
            OperationId = "GetAllDiagnostics")]
        [HttpGet]
        public async Task<IEnumerable<DiagnosticResource>> GetAllAsync()
        {
            var diagnostics = await _diagnosticService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Diagnostic>, IEnumerable<DiagnosticResource>>(diagnostics);
            return resources;
        }
        
        [SwaggerOperation(
            Summary = "Get Diagnostics By Id",
            Description = "Get Diagnostics By Id",
            OperationId = "GetDiagnosticsById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _diagnosticService.FindIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var diagnosticResource = _mapper.Map<Diagnostic, DiagnosticResource>(result.Resource);
            return Ok(diagnosticResource);    
        }
        
        [SwaggerOperation(
            Summary = "Get Claim Diagnostics By Specialty Id",
            Description = "Get Claim Diagnostics By Specialty Id",
            OperationId = "GetClaimDiagnosticsBySpecialtyId")]
        [HttpGet("/diagnostic/specialty/{id}")]
        public async Task<IEnumerable<DiagnosticResource>> GetBySpecialtyByIdAsync(int id)
        {
            var diagnostics = await _diagnosticService.ListBySpecialtyIdAsync(id);
            var resources = _mapper.Map<IEnumerable<Diagnostic>, IEnumerable<DiagnosticResource>>(diagnostics);
            return resources;
        }
        
        [SwaggerOperation(
            Summary = "Create a Diagnostic",
            Description = "Create a Diagnostic",
            OperationId = "CreateADiagnostic")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDiagnosticResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var diagnostic = _mapper.Map<SaveDiagnosticResource, Diagnostic>(resource);
            var result = await _diagnosticService.SaveAsync(diagnostic);
            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Diagnostic, DiagnosticResource>(result.Resource);
            return Ok(categoryResource);
        }
        
        [SwaggerOperation(
            Summary = "Update a Diagnostic",
            Description = "Update a Diagnostic",
            OperationId = "UpdateADiagnostic")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDiagnosticResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var diagnostic = _mapper.Map<SaveDiagnosticResource, Diagnostic>(resource);
            var result = await _diagnosticService.UpdateAsync(id, diagnostic);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var diagnosticResource = _mapper.Map<Diagnostic, DiagnosticResource>(result.Resource);
            return Ok(diagnosticResource);
        }
        
        [SwaggerOperation(
            Summary = "Delete a Diagnostic",
            Description = "Delete a Diagnostic",
            OperationId = "DeleteADiagnostic")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) {
            var result = await _diagnosticService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var diagnosticResource = _mapper.Map<Diagnostic, DiagnosticResource>(result.Resource);
            return Ok(diagnosticResource);    
        }
    }
}