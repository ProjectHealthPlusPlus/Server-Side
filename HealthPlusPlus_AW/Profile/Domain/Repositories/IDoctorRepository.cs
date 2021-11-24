using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Profile.Domain.Models;

namespace HealthPlusPlus_AW.Profile.Domain.Repositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> ListAsync();
        Task AddAsync(Doctor doctor);
        Task<Doctor> FindIdAsync(int id);
        Task<IEnumerable<Doctor>> FindBySpecialtyId(int specialtyId);
        Task<IEnumerable<Doctor>> FindByClinicId(int clinicId);
        void Update(Doctor doctor);
        void Remove(Doctor doctor);
    }
}