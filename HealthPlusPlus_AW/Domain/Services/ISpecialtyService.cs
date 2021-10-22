using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Resources;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Domain.Services
{
    public interface ISpecialtyService
    {
        Task<IEnumerable<Specialty>> ListAsync();
        Task<SaveSpecialtyResponse> SaveAsync(Specialty specialty);
        Task<SaveSpecialtyResponse> FindIdAsync(int id);
        Task<SaveSpecialtyResponse> UpdateAsync(int id, Specialty specialty);
        Task<SpecialtyResponse> DeleteAsync(int id);
    }
}