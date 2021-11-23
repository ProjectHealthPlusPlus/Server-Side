using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Profile.Domain.Models;
using HealthPlusPlus_AW.Profile.Domain.Repositories;
using HealthPlusPlus_AW.Shared.Persistance.Contexts;
using HealthPlusPlus_AW.Shared.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.Profile.Persistance
{
    public class ClinicRepository : BaseRepository, IClinicRepository
    {
        public ClinicRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Clinic>> ListAsync()
        {
            return await _context.Clinics.Include(p => p.ClinicLocation).ToListAsync();
        }

        public async Task AddAsync(Clinic clinic)
        {
            await _context.Clinics.AddAsync(clinic);
        }

        public async Task<Clinic> FindIdAsync(int id)
        {
            return await _context.Clinics.FindAsync(id);
        }

        public async Task<IEnumerable<Clinic>> FindByClinicLocationId(int clinicLocationId)
        {
            return await _context.Clinics
                .Where(p => p.ClinicLocationId == clinicLocationId)
                .Include(p => p.ClinicLocation)
                .ToListAsync();
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