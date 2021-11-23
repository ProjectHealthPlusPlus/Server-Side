using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Heal.Domain.Models;
using HealthPlusPlus_AW.Heal.Services.Communications;

namespace HealthPlusPlus_AW.Heal.Domain.Services
{
    public interface ISpecialtyService
    {
        Task<IEnumerable<Specialty>> ListAsync();
        Task<SpecialtyResponse> SaveAsync(Specialty specialty);
        Task<SpecialtyResponse> FindIdAsync(int id);
        Task<SpecialtyResponse> UpdateAsync(int id, Specialty specialty);
        Task<SpecialtyResponse> DeleteAsync(int id);
    }
}