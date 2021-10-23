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
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
        {
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Appointment>> ListAsync()
        {
            return await _appointmentRepository.ListAsync();
        }

        public async Task<SaveAppointmentResponse> SaveAsync(Appointment appointment)
        {
            try
            {
                await _appointmentRepository.AddAsync(appointment);
                await _unitOfWork.CompleteAsync();

                return new SaveAppointmentResponse(appointment);
            }
            catch (Exception e)
            {
                return new SaveAppointmentResponse($"An error occurred while saving: {e.Message}");
            }
        }

        public async Task<SaveAppointmentResponse> FindIdAsync(int id)
        {
            var existingCategory = await _appointmentRepository.FindIdAsync(id);
            try
            {
                _appointmentRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new SaveAppointmentResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new SaveAppointmentResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<SaveAppointmentResponse> UpdateAsync(int id, Appointment appointment)
        {
            var existingCategory = await _appointmentRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new SaveAppointmentResponse("Category no found.");
            
            existingCategory.StartAt = appointment.StartAt;
            existingCategory.User = appointment.User;
            existingCategory.Doctor = appointment.Doctor;
            existingCategory.AppointmentDetails = appointment.AppointmentDetails;

            try
            {
                _appointmentRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new SaveAppointmentResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new SaveAppointmentResponse($"An error occurred while updating the category: {e.Message}");
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