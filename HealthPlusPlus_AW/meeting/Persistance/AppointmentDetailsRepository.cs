using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthPlusPlus_AW.meeting.Domain.Models;
using HealthPlusPlus_AW.meeting.Domain.Repositories;
using HealthPlusPlus_AW.Shared.Persistance.Contexts;
using HealthPlusPlus_AW.Shared.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.meeting.Persistance
{
    public class AppointmentDetailsRepository : BaseRepository, IAppointmentDetailsRepository
    {
        public AppointmentDetailsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<AppointmentDetails>> ListAsync()
        {
            return await _context.AppointmentsDetails.Include(p => p.Diagnostic.Specialty).ToListAsync();
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