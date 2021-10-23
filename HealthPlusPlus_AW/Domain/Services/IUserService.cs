using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<SaveUserResponse> SaveAsync(User user);
        Task<SaveUserResponse> FindIdAsync(int id);
        Task<SaveUserResponse> UpdateAsync(int id, User user);
        Task<UserResponse> DeleteAsync(int id);
    }
}