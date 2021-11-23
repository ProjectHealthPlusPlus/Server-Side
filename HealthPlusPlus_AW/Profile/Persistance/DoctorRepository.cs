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
    public class DoctorRepository : BaseRepository, IDoctorRepository
    {
        public DoctorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Doctor>> ListAsync()
        {
            return await _context.Doctors
                .Include(x => x.Specialty)
                .Include(y => y.Clinic.ClinicLocation)
                .ToListAsync();
            
        }

        public async Task AddAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
        }

        public async Task<Doctor> FindIdAsync(int id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task<IEnumerable<Doctor>> FindBySpecialtyId(int specialtyId)
        {
            return await _context.Doctors
                .Where(p => p.SpecialtyId == specialtyId)
                .Include(p => p.Specialty)
                .ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> FindByClinicId(int clinicId)
        {
            return await _context.Doctors
                .Where(p => p.ClinicId == clinicId)
                .Include(p => p.Clinic)
                .ToListAsync();
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