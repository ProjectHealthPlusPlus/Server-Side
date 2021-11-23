using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Profile.Domain.Repositories;
using HealthPlusPlus_AW.Profile.Services.Communications;

namespace HealthPlusPlus_AW.Profile.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> FindIdAsync(int id);
        Task<UserResponse> UpdateAsync(int id, User user);
        Task<UserResponse> DeleteAsync(int id);
    }
}