using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Persistence.Contexts;
using HealthPlusPlus_AW.Persistence.Repositories;
using HealthPlusPlus_AW.Security2.Domain.Models;
using HealthPlusPlus_AW.Security2.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.Security2.Persistance.Repositories
{
    public class UserSecRepository : BaseRepository, IUserSecRepository
    {
        public UserSecRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserSec>> ListAsync()
        {
            return await _context.UserSecs.ToListAsync();
        }

        public async Task AddAsync(UserSec userSec)
        {
            await _context.UserSecs.AddAsync(userSec);
        }

        public async Task<UserSec> FindIdAsync(int id)
        {
            return await _context.UserSecs.FindAsync(id);
        }

        public async Task<UserSec> FindUsernameAsync(string username)
        {
            return await _context.UserSecs.SingleOrDefaultAsync(u=>u.Username == username);
        }

        public bool ExistByUsername(string username)
        {
            return _context.UserSecs.Any(u => u.Username == username);
        }

        public UserSec FindId(int id)
        {
            return _context.UserSecs.Find(id);
        }

        public void Update(UserSec userSec)
        {
            _context.UserSecs.Update(userSec);
        }

        public void Remove(UserSec userSec)
        {
            _context.UserSecs.Remove(userSec);
        }
    }
}