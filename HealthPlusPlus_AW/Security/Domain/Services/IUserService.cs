using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Security.Domain.Models;
using HealthPlusPlus_AW.Security.Domain.Services.Communication;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Security.Domain.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
        Task<IEnumerable<UserSec>> ListAsync();
        Task<UserSec> GetByIdAsync(int id);
        Task RegisterAsync(RegisterRequest request);
        Task UpdateAsync(int id, UpdateRequest request);
        Task DeleteAsync(int id);
    }
}