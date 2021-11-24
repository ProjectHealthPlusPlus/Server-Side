using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Heal.Domain.Models;
using HealthPlusPlus_AW.Heal.Domain.Repositories;
using HealthPlusPlus_AW.Shared.Persistance.Contexts;
using HealthPlusPlus_AW.Shared.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.Heal.Persistance
{
    public class MedicalHistoryRepository : BaseRepository, IMedicalHistoryRepository
    {
        public MedicalHistoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MedicalHistory>> ListAsync()
        {
            return await _context.MedicalHistories
                .Include(p=>p.Patient)
                .Include(x=>x.Clinic.ClinicLocation)
                .ToListAsync();
        }

        public async Task AddAsync(MedicalHistory medicalHistory)
        {
            await _context.MedicalHistories.AddAsync(medicalHistory);
        }

        public async Task<MedicalHistory> FindIdAsync(int id)
        {
            return await _context.MedicalHistories.FindAsync(id);
        }

        public async Task<IEnumerable<MedicalHistory>> FindByPatientId(int patientId)
        {
            return await _context.MedicalHistories
                .Where(p => p.PatientId == patientId)
                .Include(p => p.Patient)
                .ToListAsync();
        }

        public async Task<IEnumerable<MedicalHistory>> FindByClinicId(int clinicId)
        {
            return await _context.MedicalHistories
                .Where(p => p.ClinicId == clinicId)
                .Include(p => p.Clinic)
                .ToListAsync();
        }

        public void Update(MedicalHistory medicalHistory)
        {
            _context.MedicalHistories.Update(medicalHistory);
        }

        public void Remove(MedicalHistory medicalHistory)
        {
            _context.MedicalHistories.Remove(medicalHistory);
        }
    }
}