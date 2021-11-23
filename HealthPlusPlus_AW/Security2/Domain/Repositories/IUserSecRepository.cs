using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Security2.Domain.Models;

namespace HealthPlusPlus_AW.Security2.Domain.Repositories
{
    public interface IUserSecRepository
    {
        Task<IEnumerable<UserSec>> ListAsync();
        Task AddAsync(UserSec userSec);
        Task<UserSec> FindIdAsync(int id);
        Task<UserSec> FindUsernameAsync(string username);
        bool ExistByUsername(string username); 
        UserSec FindId(int id);
        void Update(UserSec userSec);
        void Remove(UserSec userSec);
    }
}