using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Domain.Repositories
{
    public interface IAppointmentDetailsRepository
    {
        Task<IEnumerable<AppointmentDetails>> ListAsync();
    }
}