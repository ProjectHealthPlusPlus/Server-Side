using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Persistence.Contexts;

namespace HealthPlusPlus_AW.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserService
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<User>> ListAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}