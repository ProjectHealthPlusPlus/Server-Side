using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Domain.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> ListAsync();
        Task<SaveAppointmentResponse> SaveAsync(Appointment appointment);
        Task<SaveAppointmentResponse> FindIdAsync(int id);
        Task<SaveAppointmentResponse> UpdateAsync(int id, Appointment appointment);
        Task<AppointmentResponse> DeleteAsync(int id);
    }
}