using HealthPlusPlus_AW.Persistence.Contexts;

namespace HealthPlusPlus_AW.Persistence.Repositories
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