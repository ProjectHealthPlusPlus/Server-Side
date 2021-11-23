using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Profile.Domain.Models;

namespace HealthPlusPlus_AW.Profile.Domain.Repositories
{
    public interface IClinicRepository
    {
        Task<IEnumerable<Clinic>> ListAsync();
        Task AddAsync(Clinic clinic);
        Task<Clinic> FindIdAsync(int id);
        Task<IEnumerable<Clinic>> FindByClinicLocationId(int clinicLocationId);
        void Update(Clinic clinic);
        void Remove(Clinic clinic);
    }
}