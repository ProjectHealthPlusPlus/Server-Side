using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Heal.Domain.Models;

namespace HealthPlusPlus_AW.Heal.Domain.Repositories
{
    public interface IDiagnosticRepository
    {
        Task<IEnumerable<Diagnostic>> ListAsync();
        Task AddAsync(Diagnostic diagnostic);
        Task<Diagnostic> FindIdAsync(int id);
        Task<Diagnostic> FindByNameAsync(string description);
        Task<IEnumerable<Diagnostic>> FindBySpecialtyId(int specialtyId);
        Task<IEnumerable<Diagnostic>> FindByMedicalHistoryId(int medicalHistoryId);
        void Update(Diagnostic diagnostic);
        void Remove(Diagnostic diagnostic);
    }
}