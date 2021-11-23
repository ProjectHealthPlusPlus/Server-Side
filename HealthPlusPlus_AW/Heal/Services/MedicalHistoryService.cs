using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Heal.Domain.Models;
using HealthPlusPlus_AW.Heal.Domain.Repositories;
using HealthPlusPlus_AW.Heal.Domain.Services;
using HealthPlusPlus_AW.Heal.Services.Communications;
using HealthPlusPlus_AW.Profile.Domain.Repositories;
using HealthPlusPlus_AW.Shared.Domain.Repositories;

namespace HealthPlusPlus_AW.Heal.Services
{
    public class MedicalHistoryService : IMedicalHistoryService
    {
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IClinicRepository _clinicRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MedicalHistoryService(IMedicalHistoryRepository medicalHistoryRepository, IPatientRepository patientRepository, IClinicRepository clinicRepository, IUnitOfWork unitOfWork)
        {
            _medicalHistoryRepository = medicalHistoryRepository;
            _patientRepository = patientRepository;
            _clinicRepository = clinicRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MedicalHistory>> ListAsync()
        {
            return await _medicalHistoryRepository.ListAsync();
        }

        public async Task<IEnumerable<MedicalHistory>> ListByPatientIdAsync(int patientId)
        {
            return await _medicalHistoryRepository.FindByPatientId(patientId);
        }

        public async Task<IEnumerable<MedicalHistory>> ListByClinicIdAsync(int clinicId)
        {
            return await _medicalHistoryRepository.FindByClinicId(clinicId);
        }

        public async Task<MedicalHistoryResponse> SaveAsync(MedicalHistory medicalHistory)
        {
            try
            {
                await _medicalHistoryRepository.AddAsync(medicalHistory);
                await _unitOfWork.CompleteAsync();

                return new MedicalHistoryResponse(medicalHistory);
            }
            catch (Exception e)
            {
                return new MedicalHistoryResponse($"An error occurred while saving: {e.Message}");
            }
        }

        public async Task<MedicalHistoryResponse> FindIdAsync(int id)
        {
            var existingCategory = await _medicalHistoryRepository.FindIdAsync(id);
            try
            {
                _medicalHistoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new MedicalHistoryResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new MedicalHistoryResponse($"An error occurred while updating the category: {e.Message}");
            }

        }

        public async Task<MedicalHistoryResponse> UpdateAsync(int id, MedicalHistory medicalHistory)
        {
            var existingMedicalHistory = await _medicalHistoryRepository.FindIdAsync(id);

            if (existingMedicalHistory == null)
                return new MedicalHistoryResponse("Category no found.");
            
            var existingPatient = await _patientRepository.FindIdAsync(id);

            if (existingPatient == null)
                return new MedicalHistoryResponse("Patient no found.");
            
            var existingClinic = await _clinicRepository.FindIdAsync(id);

            if (existingClinic == null)
                return new MedicalHistoryResponse("Clinic no found.");
            
            existingMedicalHistory.PatientId = medicalHistory.PatientId;
            existingMedicalHistory.ClinicId = medicalHistory.ClinicId;

            try
            {
                _medicalHistoryRepository.Update(existingMedicalHistory);
                await _unitOfWork.CompleteAsync();

                return new MedicalHistoryResponse(existingMedicalHistory);
            }
            catch (Exception e)
            {
                return new MedicalHistoryResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<MedicalHistoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await _medicalHistoryRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new MedicalHistoryResponse("Category not found.");

            try
            {
                _medicalHistoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new MedicalHistoryResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new MedicalHistoryResponse($"An error occurred while deleting category: {e.Message}");
            }
        }
    }
}