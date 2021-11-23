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
    public class DiagnosticRepository : BaseRepository, IDiagnosticRepository
    {
        public DiagnosticRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Diagnostic>> ListAsync()
        {
            return await _context.Diagnostics
                .Include(p => p.Specialty)
                .Include(x=>x.MedicalHistory.Patient)
                .Include(y=>y.MedicalHistory.Clinic.ClinicLocation)
                .ToListAsync();
        }

        public async Task AddAsync(Diagnostic diagnostic)
        {
            await _context.Diagnostics.AddAsync(diagnostic);
        }

        public async Task<Diagnostic> FindIdAsync(int id)
        {
            return await _context.Diagnostics
                .Include(p => p.Specialty)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Diagnostic> FindByNameAsync(string description)
        {
            return await _context.Diagnostics
                .Include(p => p.Specialty)
                .FirstOrDefaultAsync(p => p.Description == description);
        }

        public async Task<IEnumerable<Diagnostic>> FindBySpecialtyId(int specialtyId)
        {
            return await _context.Diagnostics
                .Where(p => p.SpecialtyId == specialtyId)
                .Include(p => p.Specialty)
                .ToListAsync();
        }

        public async Task<IEnumerable<Diagnostic>> FindByMedicalHistoryId(int medicalHistoryId)
        {
            return await _context.Diagnostics
                .Where(p => p.MedicalHistoryId == medicalHistoryId)
                .Include(p => p.MedicalHistory)
                .ToListAsync();
        }

        public void Update(Diagnostic diagnostic)
        {
            _context.Diagnostics.Update(diagnostic);
        }

        public void Remove(Diagnostic diagnostic)
        {
            _context.Diagnostics.Remove(diagnostic);
        }
    }
}