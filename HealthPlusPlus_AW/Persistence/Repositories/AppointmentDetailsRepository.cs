using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.Persistence.Repositories
{
    public class AppointmentDetailsRepository : BaseRepository, IAppointmentDetailsRepository
    {
        public AppointmentDetailsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<AppointmentDetails>> ListAsync()
        {
<<<<<<< Updated upstream
            return await _context.AppointmentsDetails.ToListAsync();
=======
            return await _context.AppointmentsDetails
                .Include(p => p.Diagnostic.Specialty)
                .ToListAsync();
>>>>>>> Stashed changes
        }

        public async Task AddAsync(AppointmentDetails appointmentDetails)
        {
            await _context.AppointmentsDetails.AddAsync(appointmentDetails);
        }

        public async Task<AppointmentDetails> FindIdAsync(int id)
        {
            return await _context.AppointmentsDetails.FindAsync(id);
        }

        public async Task<IEnumerable<AppointmentDetails>> FindByDiagnosticId(int diagnosticId)
        {
            return await _context.AppointmentsDetails
                .Where(p => p.DiagnosticId == diagnosticId)
                .Include(p => p.Diagnostic)
                .ToListAsync();
        }

        public void Update(AppointmentDetails appointmentDetails)
        {
            _context.AppointmentsDetails.Update(appointmentDetails);
        }

        public void Remove(AppointmentDetails appointmentDetails)
        {
            _context.AppointmentsDetails.Remove(appointmentDetails);
        }
    }
}