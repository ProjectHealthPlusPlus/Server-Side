using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> ListAsync();
        Task AddAsync(Appointment appointment);
        Task<Appointment> FindIdAsync(int id);
        void Update(Appointment appointment);
        void Remove(Appointment appointment);
    }
}