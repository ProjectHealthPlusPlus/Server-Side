using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthPlusPlus_AW.Profile.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User user);
        Task<User> FindIdAsync(int id);
        void Update(User user);
        void Remove(User user);
    }
}