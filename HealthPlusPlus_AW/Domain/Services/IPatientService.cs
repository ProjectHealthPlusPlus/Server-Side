using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Domain.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> ListAsync();
        Task<SavePatientResponse> SaveAsync(Patient patient);
        Task<SavePatientResponse> FindIdAsync(int id);
        Task<SavePatientResponse> UpdateAsync(int id, Patient patient);
        Task<PatientResponse> DeleteAsync(int id);
    }
}