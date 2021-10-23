using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Domain.Repositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> ListAsync();
        Task AddAsync(Doctor doctor);
        Task<Doctor> FindIdAsync(int id);
        void Update(Doctor doctor);
        void Remove(Doctor doctor);
    }
}