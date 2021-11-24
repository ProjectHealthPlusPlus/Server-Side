using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Example.Domain.Models;
using HealthPlusPlus_AW.Example.Domain.Repositories;
using HealthPlusPlus_AW.Shared.Persistance.Contexts;
using HealthPlusPlus_AW.Shared.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.Example.Persistence.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task<Product> FindIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> FindByNameAsync(string name)
        {
            return await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<IEnumerable<Product>> FindByCategoryId(int categoryId)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }

 
    }
}