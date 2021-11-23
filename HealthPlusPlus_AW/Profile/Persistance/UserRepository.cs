using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Profile.Domain.Repositories;
using HealthPlusPlus_AW.Shared.Persistance.Contexts;
using HealthPlusPlus_AW.Shared.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.Profile.Persistance
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

         public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

         public async Task AddAsync(User user)
         {
             await _context.Users.AddAsync(user);
         }

         public async Task<User> FindIdAsync(int id)
         {
             return await _context.Users.FindAsync(id);
         }

         public void Update(User user)
         {
             _context.Users.Update(user);
         }

         public void Remove(User user)
         {
             _context.Users.Remove(user);
         }
    }
}