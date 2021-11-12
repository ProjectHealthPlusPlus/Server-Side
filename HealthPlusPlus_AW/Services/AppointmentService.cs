using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IAppointmentDetailsRepository _appointmentDetailsRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork, IAppointmentDetailsRepository appointmentDetailsRepository, IPatientRepository patientRepository, IDoctorRepository doctorRepository)
        {
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
            _appointmentDetailsRepository = appointmentDetailsRepository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<IEnumerable<Appointment>> ListAsync()
        {
            return await _appointmentRepository.ListAsync();
        }

        public async Task<IEnumerable<Appointment>> ListByAppointmentDetailsIdAsync(int appointmentDetailsId)
        {
            return await _appointmentRepository.FindByAppointmentDetailsIdAsync(appointmentDetailsId);
        }

        public async Task<IEnumerable<Appointment>> ListByPatientIdAsync(int patientId)
        {
            return await _appointmentRepository.FindByPatientIdAsync(patientId);
        }

        public async Task<IEnumerable<Appointment>> ListByDoctorIdAsync(int doctorId)
        {
            return await _appointmentRepository.FindByDoctorIdAsync(doctorId);
        }

        public async Task<AppointmentResponse> SaveAsync(Appointment appointment)
        {
            try
            {
                await _appointmentRepository.AddAsync(appointment);
                await _unitOfWork.CompleteAsync();

                return new AppointmentResponse(appointment);
            }
            catch (Exception e)
            {
                return new AppointmentResponse($"An error occurred while saving: {e.Message}");
            }
        }

        public async Task<AppointmentResponse> FindIdAsync(int id)
        {
            var existingCategory = await _appointmentRepository.FindIdAsync(id);
            try
            {
                _appointmentRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new AppointmentResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new AppointmentResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<AppointmentResponse> UpdateAsync(int id, Appointment appointment)
        {
            var existingAppointment = await _appointmentRepository.FindIdAsync(id);

            if (existingAppointment == null)
                return new AppointmentResponse("Appointment no found.");
            
            var existingAppointmentDetails = await _appointmentDetailsRepository.FindIdAsync(id);

            if (existingAppointmentDetails == null)
                return new AppointmentResponse("Patient no found.");
            
            var existingPatient = await _patientRepository.FindIdAsync(id);

            if (existingPatient == null)
                return new AppointmentResponse("Patient no found.");
            
            var existingDoctor = await _doctorRepository.FindIdAsync(id);

            if (existingDoctor == null)
                return new AppointmentResponse("Doctor no found.");

            existingAppointment.StartAt = appointment.StartAt;
            existingAppointment.AppointmentDetailsId = appointment.AppointmentDetailsId;
            existingAppointment.PatientId = appointment.PatientId;
            existingAppointment.DoctorId = appointment.DoctorId;

            try
            {
                _appointmentRepository.Update(existingAppointment);
                await _unitOfWork.CompleteAsync();

                return new AppointmentResponse(existingAppointment);
            }
            catch (Exception e)
            {
                return new AppointmentResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<AppointmentResponse> DeleteAsync(int id)
        {
            var existingCategory = await _appointmentRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new AppointmentResponse("Category not found.");

            try
            {
                _appointmentRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new AppointmentResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new AppointmentResponse($"An error occurred while deleting category: {e.Message}");
            }
        }
    }
}