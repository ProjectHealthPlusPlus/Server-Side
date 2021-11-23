using HealthPlusPlus_AW.Shared.Persistance.Contexts;

namespace HealthPlusPlus_AW.Shared.Persistance.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;
        
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}