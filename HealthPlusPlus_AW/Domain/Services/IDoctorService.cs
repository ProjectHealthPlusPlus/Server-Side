using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Domain.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> ListAsync();
        Task<SaveDoctorResponse> SaveAsync(Doctor doctor);
        Task<SaveDoctorResponse> FindIdAsync(int id);
        Task<SaveDoctorResponse> UpdateAsync(int id, Doctor doctor);
        Task<DoctorResponse> DeleteAsync(int id);
    }
}