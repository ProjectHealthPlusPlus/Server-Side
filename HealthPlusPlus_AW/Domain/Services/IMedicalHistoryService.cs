using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Domain.Services
{
    public interface IMedicalHistoryService
    {
        Task<IEnumerable<MedicalHistory>> ListAsync();
        Task<SaveMedicalHistoryResponse> SaveAsync(MedicalHistory medicalHistory);
        Task<SaveMedicalHistoryResponse> FindIdAsync(int id);
        Task<SaveMedicalHistoryResponse> UpdateAsync(int id, MedicalHistory medicalHistory);
        Task<MedicalHistoryResponse> DeleteAsync(int id);
    }
}