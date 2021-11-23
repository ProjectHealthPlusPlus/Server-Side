using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Heal.Domain.Repositories;
using HealthPlusPlus_AW.meeting.Domain.Models;
using HealthPlusPlus_AW.meeting.Domain.Repositories;
using HealthPlusPlus_AW.meeting.Domain.Services;
using HealthPlusPlus_AW.meeting.Services.Communications;
using HealthPlusPlus_AW.Shared.Domain.Repositories;

namespace HealthPlusPlus_AW.meeting.Services
{
    public class AppointmentDetailsService : IAppointmentDetailsService
    {
        private readonly IAppointmentDetailsRepository _appointmentDetailsRepository;
        private readonly IDiagnosticRepository _diagnosticRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentDetailsService(IAppointmentDetailsRepository appointmentDetailsRepository, IUnitOfWork unitOfWork, IDiagnosticRepository diagnosticRepository)
        {
            _appointmentDetailsRepository = appointmentDetailsRepository;
            _unitOfWork = unitOfWork;
            _diagnosticRepository = diagnosticRepository;
        }

        public async Task<IEnumerable<AppointmentDetails>> ListAsync()
        {
            return await _appointmentDetailsRepository.ListAsync();
        }

        public async Task<IEnumerable<AppointmentDetails>> ListByDiagnosticIdAsync(int diagnosticId)
        {
            return await _appointmentDetailsRepository.FindByDiagnosticId(diagnosticId);
        }

        public async Task<AppointmentDetailsResponse> SaveAsync(AppointmentDetails appointmentDetails)
        {
            try
            {
                await _appointmentDetailsRepository.AddAsync(appointmentDetails);
                await _unitOfWork.CompleteAsync();

                return new AppointmentDetailsResponse(appointmentDetails);
            }
            catch (Exception e)
            {
                return new AppointmentDetailsResponse($"An error occurred while saving: {e.Message}");
            }
        }

        public async Task<AppointmentDetailsResponse> FindIdAsync(int id)
        {
            var existingCategory = await _appointmentDetailsRepository.FindIdAsync(id);
            try
            {
                _appointmentDetailsRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new AppointmentDetailsResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new AppointmentDetailsResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<AppointmentDetailsResponse> UpdateAsync(int id, AppointmentDetails appointmentDetails)
        {
            var existingAppointmentDetails = await _appointmentDetailsRepository.FindIdAsync(id);

            if (existingAppointmentDetails == null)
                return new AppointmentDetailsResponse("Category no found.");
            
            var existingDiagnostic = await _diagnosticRepository.FindIdAsync(id);

            if (existingDiagnostic == null)
                return new AppointmentDetailsResponse("Diagnostic no found.");
            
            existingAppointmentDetails.UserStartAt = appointmentDetails.UserStartAt;
            existingAppointmentDetails.DoctorStartAt = appointmentDetails.DoctorStartAt;
            existingAppointmentDetails.UserEndAt = appointmentDetails.UserEndAt;
            existingAppointmentDetails.DoctorEndAt = appointmentDetails.DoctorEndAt;
            existingAppointmentDetails.DiagnosticId = appointmentDetails.DiagnosticId;

            try
            {
                _appointmentDetailsRepository.Update(existingAppointmentDetails);
                await _unitOfWork.CompleteAsync();

                return new AppointmentDetailsResponse(existingAppointmentDetails);
            }
            catch (Exception e)
            {
                return new AppointmentDetailsResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<AppointmentDetailsResponse> DeleteAsync(int id)
        {
            var existingCategory = await _appointmentDetailsRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new AppointmentDetailsResponse("Category not found.");

            try
            {
                _appointmentDetailsRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new AppointmentDetailsResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new AppointmentDetailsResponse($"An error occurred while deleting category: {e.Message}");
            }
        }
    }
}