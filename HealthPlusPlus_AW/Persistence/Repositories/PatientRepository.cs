using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.Persistence.Repositories
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
            return await _context.Patients.FindAsync();
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