using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Heal.Domain.Models;

namespace HealthPlusPlus_AW.Heal.Domain.Repositories
{
    public interface ISpecialtyRepository
    {
        Task<IEnumerable<Specialty>> ListAsync();
        Task AddAsync(Specialty specialty);
        Task<Specialty> FindIdAsync(int id);
        void Update(Specialty specialty);
        void Remove(Specialty specialty);
    }
}