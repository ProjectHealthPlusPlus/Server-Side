using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Domain.Services
{
    public interface IClinicLocationService
    {
        Task<IEnumerable<ClinicLocation>> ListAsync();
        Task<SaveClinicLocationResponse> SaveAsync(ClinicLocation clinicLocation);
        Task<SaveClinicLocationResponse> FindIdAsync(int id);
        Task<SaveClinicLocationResponse> UpdateAsync(int id, ClinicLocation clinicLocation);
        Task<ClinicLocationResponse> DeleteAsync(int id);
    }
}