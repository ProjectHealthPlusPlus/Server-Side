using System.Threading.Tasks;
using HealthPlusPlus_AW.Shared.Domain.Repositories;
using HealthPlusPlus_AW.Shared.Persistance.Contexts;

namespace HealthPlusPlus_AW.Shared.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}