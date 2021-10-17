using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Resources;

namespace HealthPlusPlus_AW.Domain.Services
{
    public interface ISpecialtyService
    {
        Task<IEnumerable<Specialty>> ListAsync();
    }
}