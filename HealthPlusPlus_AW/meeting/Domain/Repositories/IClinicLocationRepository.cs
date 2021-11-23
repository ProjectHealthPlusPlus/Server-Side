using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.meeting.Domain.Models;

namespace HealthPlusPlus_AW.meeting.Domain.Repositories
{
    public interface IClinicLocationRepository
    {
        Task<IEnumerable<ClinicLocation>> ListAsync();
        Task AddAsync(ClinicLocation clinicLocation);
        Task<ClinicLocation> FindIdAsync(int id);
        void Update(ClinicLocation clinicLocation);
        void Remove(ClinicLocation clinicLocation);
    }
}