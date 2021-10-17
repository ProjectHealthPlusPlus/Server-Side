using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.Persistence.Repositories
{
    public class ClinicLocationRepository : BaseRepository, IClinicLocationService
    {
        public ClinicLocationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ClinicLocation>> ListAsync()
        {
            return await _context.ClinicLocations.ToListAsync();
        }
    }
}