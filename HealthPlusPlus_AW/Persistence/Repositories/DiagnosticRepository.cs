using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.Persistence.Repositories
{
    public class DiagnosticRepository : BaseRepository, IDiagnosticRepository
    {
        public DiagnosticRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Diagnostic>> ListAsync()
        {
            return await _context.Diagnostics.ToListAsync();
        }

        public async Task AddAsync(Diagnostic diagnostic)
        {
            await _context.Diagnostics.AddAsync(diagnostic);
        }

        public async Task<Diagnostic> FindIdAsync(int id)
        {
            return await _context.Diagnostics.FindAsync(id);
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