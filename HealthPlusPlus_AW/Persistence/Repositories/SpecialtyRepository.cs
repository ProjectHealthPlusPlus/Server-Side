using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.Persistence.Repositories
{
    public class SpecialtyRepository : BaseRepository, ISpecialtyRepository
    {
        public SpecialtyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Specialty>> ListAsync()
        {
            return await _context.Specialties.ToListAsync();
        }

        public async Task AddAsync(Specialty specialty)
        {
            await _context.Specialties.AddAsync(specialty);
        }

        public async Task<Specialty> FindIdAsync(int id)
        {
            return await _context.Specialties.FindAsync(id);
        }

        public void Update(Specialty specialty)
        {
            _context.Specialties.Update(specialty);
        }

        public void Remove(Specialty specialty)
        {
            _context.Specialties.Remove(specialty);
        }
    }
}