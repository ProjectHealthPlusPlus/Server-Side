using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Domain.Services
{
    public interface IAppointmentDetailsService
    {
        Task<IEnumerable<AppointmentDetails>> ListAsync();
        Task<SaveAppointmentDetailsResponse> SaveAsync(AppointmentDetails appointmentDetails);
        Task<SaveAppointmentDetailsResponse> FindIdAsync(int id);
        Task<SaveAppointmentDetailsResponse> UpdateAsync(int id, AppointmentDetails appointmentDetails);
        Task<AppointmentDetailsResponse> DeleteAsync(int id);
    }
}