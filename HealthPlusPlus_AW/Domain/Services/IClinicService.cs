using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Domain.Services
{
    public interface IClinicService
    {
        Task<IEnumerable<Clinic>> ListAsync();
        Task<SaveClinicResponse> SaveAsync(Clinic clinic);
        Task<SaveClinicResponse> FindIdAsync(int id);
        Task<SaveClinicResponse> UpdateAsync(int id, Clinic clinic);
        Task<ClinicResponse> DeleteAsync(int id);
    }
}