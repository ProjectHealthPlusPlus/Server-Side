using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.meeting.Domain.Models;
using HealthPlusPlus_AW.meeting.Services.Communications;

namespace HealthPlusPlus_AW.meeting.Domain.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> ListAsync();
        Task<IEnumerable<Appointment>> ListByAppointmentDetailsIdAsync(int appointmentDetailsId);
        Task<IEnumerable<Appointment>> ListByPatientIdAsync(int patientId);
        Task<IEnumerable<Appointment>> ListByDoctorIdAsync(int doctorId);
        Task<AppointmentResponse> SaveAsync(Appointment appointment);
        Task<AppointmentResponse> FindIdAsync(int id);
        Task<AppointmentResponse> UpdateAsync(int id, Appointment appointment);
        Task<AppointmentResponse> DeleteAsync(int id);
    }
}