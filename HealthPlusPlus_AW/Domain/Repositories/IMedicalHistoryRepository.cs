using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Domain.Repositories
{
    public interface IMedicalHistoryRepository
    {
        Task<IEnumerable<MedicalHistory>> ListAsync();
        Task AddAsync(MedicalHistory medicalHistory);
        Task<MedicalHistory> FindIdAsync(int id);
        void Update(MedicalHistory medicalHistory);
        void Remove(MedicalHistory medicalHistory);
    }
}