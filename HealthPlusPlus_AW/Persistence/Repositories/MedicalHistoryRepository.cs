using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.Persistence.Repositories
{
    public class MedicalHistoryRepository : BaseRepository, IMedicalHistoryRepository
    {
        public MedicalHistoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MedicalHistory>> ListAsync()
        {
            return await _context.MedicalHistories.ToListAsync();
        }

        public async Task AddAsync(MedicalHistory medicalHistory)
        {
            await _context.MedicalHistories.AddAsync(medicalHistory);
        }

        public async Task<MedicalHistory> FindIdAsync(int id)
        {
            return await _context.MedicalHistories.FindAsync(id);
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