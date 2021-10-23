using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.Persistence.Repositories
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