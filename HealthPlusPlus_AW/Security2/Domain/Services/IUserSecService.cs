using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Security2.Domain.Models;
using HealthPlusPlus_AW.Security2.Domain.Services.Communication;

namespace HealthPlusPlus_AW.Security2.Domain.Services
{
    public interface IUserSecService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
        Task<IEnumerable<UserSec>> ListAsync();
        Task<UserSec> GetByIdAsync(int id);
        Task RegisterAsync(RegisterRequest request);
        Task UpdateAsync(int id, UpdateRequest request);
        Task DeleteAsync(int id);
    }
}