using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Domain.Services
{
    public interface IAppointmentDetailsService
    {
        Task<IEnumerable<AppointmentDetails>> ListAsync();
        Task<IEnumerable<AppointmentDetails>> ListByDiagnosticIdAsync(int diagnosticId);
        Task<AppointmentDetailsResponse> SaveAsync(AppointmentDetails appointmentDetails);
        Task<AppointmentDetailsResponse> FindIdAsync(int id);
        Task<AppointmentDetailsResponse> UpdateAsync(int id, AppointmentDetails appointmentDetails);
        Task<AppointmentDetailsResponse> DeleteAsync(int id);
    }
}