using System.Collections.Generic;
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
            return await _context.AppointmentsDetails.ToListAsync();
        }

        public async Task AddAsync(AppointmentDetails appointmentDetails)
        {
            await _context.AppointmentsDetails.AddAsync(appointmentDetails);
        }

        public async Task<AppointmentDetails> FindIdAsync(int id)
        {
            return await _context.AppointmentsDetails.FindAsync(id);
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