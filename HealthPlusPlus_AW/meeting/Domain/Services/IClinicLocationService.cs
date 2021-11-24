using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.meeting.Domain.Models;
using HealthPlusPlus_AW.meeting.Services.Communications;

namespace HealthPlusPlus_AW.meeting.Domain.Services
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