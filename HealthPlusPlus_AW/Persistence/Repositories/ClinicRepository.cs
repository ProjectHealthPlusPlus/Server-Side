using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.Persistence.Repositories
{
    public class ClinicRepository : BaseRepository, IClinicService
    {
        public ClinicRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Clinic>> ListAsync()
        {
            return await _context.Clinics.ToListAsync();
        }
    }
}