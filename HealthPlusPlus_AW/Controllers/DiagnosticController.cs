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
    public class DiagnosticController : ControllerBase
    {
        private readonly IDiagnosticService _diagnosticService;
        private readonly IMapper _mapper;

        public DiagnosticController(IDiagnosticService diagnosticService, IMapper mapper)
        {
            _diagnosticService = diagnosticService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DiagnosticResource>> GetAllAsync()
        {
            var diagnostics = await _diagnosticService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Diagnostic>, IEnumerable<DiagnosticResource>>(diagnostics);
            return resources;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _diagnosticService.FindIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var diagnosticResource = _mapper.Map<Diagnostic, DiagnosticResource>(result.Diagnostic);
            return Ok(diagnosticResource);    
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDiagnosticResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var diagnostic = _mapper.Map<SaveDiagnosticResource, Diagnostic>(resource);
            var result = await _diagnosticService.SaveAsync(diagnostic);
            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Diagnostic, DiagnosticResource>(result.Diagnostic);
            return Ok(categoryResource);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDiagnosticResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var diagnostic = _mapper.Map<SaveDiagnosticResource, Diagnostic>(resource);
            var result = await _diagnosticService.UpdateAsync(id, diagnostic);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var diagnosticResource = _mapper.Map<Diagnostic, DiagnosticResource>(result.Diagnostic);
            return Ok(diagnosticResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) {
            var result = await _diagnosticService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var diagnosticResource = _mapper.Map<Diagnostic, DiagnosticResource>(result.Diagnostic);
            return Ok(diagnosticResource);    
        }
    }
}