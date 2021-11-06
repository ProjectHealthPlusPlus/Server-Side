using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Domain.Services
{
    public interface IClinicService
    {
        Task<IEnumerable<Clinic>> ListAsync();
        Task<IEnumerable<Clinic>> ListByClinicLocationIdAsync(int clinicLocationId);
        Task<ClinicResponse> SaveAsync(Clinic clinic);
        Task<ClinicResponse> FindIdAsync(int id);
        Task<ClinicResponse> UpdateAsync(int id, Clinic clinic);
        Task<ClinicResponse> DeleteAsync(int id);
    }
}