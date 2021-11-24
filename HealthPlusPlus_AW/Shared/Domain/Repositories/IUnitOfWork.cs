using System.Threading.Tasks;

namespace HealthPlusPlus_AW.Shared.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}