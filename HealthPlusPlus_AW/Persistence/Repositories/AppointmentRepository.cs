using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.Persistence.Repositories
{
    public class AppointmentRepository : BaseRepository, IAppointmentRepository
    {

        public AppointmentRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Appointment>> ListAsync()
        {
            return await _context.Appointments
                .Include(p=>p.AppointmentDetails.Diagnostic.Specialty)
                .Include(x => x.Patient)
                .Include(y => y.Doctor.Clinic.ClinicLocation)
                .ToListAsync();
        }

        public async Task AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
        }

        public async Task<Appointment> FindIdAsync(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task<IEnumerable<Appointment>> FindByAppointmentDetailsIdAsync(int appointmentDetailsId)
        {
            return await _context.Appointments
                .Where(p => p.AppointmentDetailsId == appointmentDetailsId)
                .Include(p => p.AppointmentDetails)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> FindByPatientIdAsync(int patientId)
        {
            return await _context.Appointments
                .Where(p => p.PatientId == patientId)
                .Include(p => p.Patient)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> FindByDoctorIdAsync(int doctorId)
        {
            return await _context.Appointments
                .Where(p => p.DoctorId == doctorId)
                .Include(p => p.Doctor)
                .ToListAsync();
        }

        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
        }

        public void Remove(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
        }
    }
}