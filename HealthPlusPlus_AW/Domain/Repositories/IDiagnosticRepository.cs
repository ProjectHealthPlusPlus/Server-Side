using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Domain.Repositories
{
    public interface IDiagnosticRepository
    {
        Task<IEnumerable<Diagnostic>> ListAsync();
        Task AddAsync(Diagnostic diagnostic);
        Task<Diagnostic> FindIdAsync(int id);
        void Update(Diagnostic diagnostic);
        void Remove(Diagnostic diagnostic);
    }
}