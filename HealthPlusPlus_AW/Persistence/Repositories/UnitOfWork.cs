using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Persistence.Contexts;

namespace HealthPlusPlus_AW.Persistence.Repositories
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