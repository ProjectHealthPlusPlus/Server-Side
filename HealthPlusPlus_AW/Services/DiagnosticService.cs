using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;

namespace HealthPlusPlus_AW.Services
{
    public class DiagnosticService : IDiagnosticService
    {
        private readonly IDiagnosticRepository _diagnosticRepository;

        public DiagnosticService(IDiagnosticRepository diagnosticRepository)
        {
            _diagnosticRepository = diagnosticRepository;
        }

        public async Task<IEnumerable<Diagnostic>> ListAsync()
        {
            return await _diagnosticRepository.ListAsync();
        }
    }
}