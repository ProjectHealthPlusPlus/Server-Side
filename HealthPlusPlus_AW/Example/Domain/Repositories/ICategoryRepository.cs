using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Example.Domain.Models;

namespace HealthPlusPlus_AW.Example.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
        Task AddAsync(Category category);
        Task<Category> FindIdAsync(int id);
        void Update(Category category);
        void Remove(Category category);
    }
}