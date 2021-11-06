using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Domain.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> ListAsync();
        Task<PatientResponse> SaveAsync(Patient patient);
        Task<PatientResponse> FindIdAsync(int id);
        Task<PatientResponse> UpdateAsync(int id, Patient patient);
        Task<PatientResponse> DeleteAsync(int id);
    }
}