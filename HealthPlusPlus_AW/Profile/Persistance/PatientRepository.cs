using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Profile.Domain.Models;
using HealthPlusPlus_AW.Profile.Domain.Repositories;
using HealthPlusPlus_AW.Shared.Persistance.Contexts;
using HealthPlusPlus_AW.Shared.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.Profile.Persistance
{
    public class PatientRepository : BaseRepository, IPatientRepository
    {
        public PatientRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Patient>> ListAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
        }

        public async Task<Patient> FindIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public void Update(Patient patient)
        {
            _context.Patients.Update(patient);
        }

        public void Remove(Patient patient)
        {
            _context.Patients.Remove(patient);
        }
    }
}