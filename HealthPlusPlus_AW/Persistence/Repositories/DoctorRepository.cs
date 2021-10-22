using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.Persistence.Repositories
{
    public class DoctorRepository : BaseRepository, IDoctorRepository
    {
        public DoctorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Doctor>> ListAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task AddAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
        }

        public async Task<Doctor> FindIdAsync(int id)
        {
            return await _context.Doctors.FindAsync();
        }

        public void Update(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
        }

        public void Remove(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
        }
    }
}