using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.Persistence.Repositories
{
    public class AppointmentDetailsRepository : BaseRepository, IAppointmentDetailsService
    {
        public AppointmentDetailsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<AppointmentDetails>> ListAsync()
        {
            return await _context.AppointmentsDetails.ToListAsync();
        }
    }
}