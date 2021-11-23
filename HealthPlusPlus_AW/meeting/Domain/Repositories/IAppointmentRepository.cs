using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.meeting.Domain.Models;

namespace HealthPlusPlus_AW.meeting.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> ListAsync();
        Task AddAsync(Appointment appointment);
        Task<Appointment> FindIdAsync(int id);
        Task<IEnumerable<Appointment>> FindByAppointmentDetailsIdAsync(int appointmentDetailsId);
        Task<IEnumerable<Appointment>> FindByPatientIdAsync(int patientId);
        Task<IEnumerable<Appointment>> FindByDoctorIdAsync(int doctorId);
        void Update(Appointment appointment);
        void Remove(Appointment appointment);
    }
}