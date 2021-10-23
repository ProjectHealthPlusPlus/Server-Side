using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Domain.Repositories
{
    public interface IClinicRepository
    {
        Task<IEnumerable<Clinic>> ListAsync();
        Task AddAsync(Clinic clinic);
        Task<Clinic> FindIdAsync(int id);
        void Update(Clinic clinic);
        void Remove(Clinic clinic);
    }
}