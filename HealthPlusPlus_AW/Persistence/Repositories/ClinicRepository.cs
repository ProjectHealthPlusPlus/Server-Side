using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.Persistence.Repositories
{
    public class ClinicRepository : BaseRepository, IClinicRepository
    {
        public ClinicRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Clinic>> ListAsync()
        {
            return await _context.Clinics.ToListAsync();
        }

        public async Task AddAsync(Clinic clinic)
        {
            await _context.Clinics.AddAsync(clinic);
        }

        public async Task<Clinic> FindIdAsync(int id)
        {
            return await _context.Clinics.FindAsync();
        }

        public void Update(Clinic clinic)
        {
            _context.Clinics.Update(clinic);
        }

        public void Remove(Clinic clinic)
        {
            _context.Clinics.Remove(clinic);
        }
    }
}