using System.Threading.Tasks;

namespace HealthPlusPlus_AW.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}