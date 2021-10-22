using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Domain.Services
{
    public interface IDiagnosticService
    {
        Task<IEnumerable<Diagnostic>> ListAsync();
        Task<SaveDiagnosticResponse> SaveAsync(Diagnostic diagnostic);
        Task<SaveDiagnosticResponse> FindIdAsync(int id);
        Task<SaveDiagnosticResponse> UpdateAsync(int id, Diagnostic diagnostic);
        Task<DiagnosticResponse> DeleteAsync(int id);
    }
}