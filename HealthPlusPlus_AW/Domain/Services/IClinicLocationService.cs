using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Domain.Services
{
    public interface IClinicLocationService
    {
        Task<IEnumerable<ClinicLocation>> ListAsync();
        Task<ClinicLocationResponse> SaveAsync(ClinicLocation clinicLocation);
        Task<ClinicLocationResponse> FindIdAsync(int id);
        Task<ClinicLocationResponse> UpdateAsync(int id, ClinicLocation clinicLocation);
        Task<ClinicLocationResponse> DeleteAsync(int id);
    }
}