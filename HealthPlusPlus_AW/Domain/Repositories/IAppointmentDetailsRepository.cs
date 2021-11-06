using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Domain.Repositories
{
    public interface IAppointmentDetailsRepository
    {
        Task<IEnumerable<AppointmentDetails>> ListAsync();
        Task AddAsync(AppointmentDetails appointmentDetails);
        Task<AppointmentDetails> FindIdAsync(int id);
        Task<IEnumerable<AppointmentDetails>> FindByDiagnosticId(int diagnosticId);
        void Update(AppointmentDetails appointmentDetails);
        void Remove(AppointmentDetails appointmentDetails);
    }
}