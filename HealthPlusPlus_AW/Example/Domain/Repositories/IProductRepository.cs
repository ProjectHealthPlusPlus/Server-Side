using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Example.Domain.Models;

namespace HealthPlusPlus_AW.Example.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task AddAsync(Product product);
        Task<Product> FindIdAsync(int id);
        Task<Product> FindByNameAsync(string name);
        Task<IEnumerable<Product>> FindByCategoryId(int categoryId);
        void Update(Product product);
        void Remove(Product product);
    }
}