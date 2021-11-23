using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Example.Domain.Models;
using HealthPlusPlus_AW.Example.Services.Communications;

namespace HealthPlusPlus_AW.Example.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId);
        Task<ProductResponse> SaveAsync(Product product);
        Task<ProductResponse> UpdateAsync(int id, Product product);
        Task<ProductResponse> DeleteAsync(int id);
    }
}