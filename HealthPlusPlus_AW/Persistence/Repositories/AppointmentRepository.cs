using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.Persistence.Repositories
{
    public class AppointmentRepository : BaseRepository, IAppointmentRepository
    {
        public AppointmentRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Appointment>> ListAsync()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
        }

        public async Task<Appointment> FindIdAsync(int id)
        {
            return await _context.Appointments.FindAsync();
        }

        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
        }

        public void Remove(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
        }
    }
}