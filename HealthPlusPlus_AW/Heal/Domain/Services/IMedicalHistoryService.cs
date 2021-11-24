using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Heal.Domain.Models;
using HealthPlusPlus_AW.Heal.Services.Communications;

namespace HealthPlusPlus_AW.Heal.Domain.Services
{
    public interface IMedicalHistoryService
    {
        Task<IEnumerable<MedicalHistory>> ListAsync();
        Task<IEnumerable<MedicalHistory>> ListByPatientIdAsync(int patientId);
        Task<IEnumerable<MedicalHistory>> ListByClinicIdAsync(int clinicId);
        Task<MedicalHistoryResponse> SaveAsync(MedicalHistory medicalHistory);
        Task<MedicalHistoryResponse> FindIdAsync(int id);
        Task<MedicalHistoryResponse> UpdateAsync(int id, MedicalHistory medicalHistory);
        Task<MedicalHistoryResponse> DeleteAsync(int id);
    }
}