using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Services
{
    public class MedicalHistoryService : IMedicalHistoryService
    {
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MedicalHistoryService(IMedicalHistoryRepository medicalHistoryRepository, IUnitOfWork unitOfWork)
        {
            _medicalHistoryRepository = medicalHistoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MedicalHistory>> ListAsync()
        {
            return await _medicalHistoryRepository.ListAsync();
        }

        public async Task<SaveMedicalHistoryResponse> SaveAsync(MedicalHistory medicalHistory)
        {
            try
            {
                await _medicalHistoryRepository.AddAsync(medicalHistory);
                await _unitOfWork.CompleteAsync();

                return new SaveMedicalHistoryResponse(medicalHistory);
            }
            catch (Exception e)
            {
                return new SaveMedicalHistoryResponse($"An error occurred while saving: {e.Message}");
            }
        }

        public Task<SaveMedicalHistoryResponse> FindIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<SaveMedicalHistoryResponse> UpdateAsync(int id, MedicalHistory medicalHistory)
        {
            var existingCategory = await _medicalHistoryRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new SaveMedicalHistoryResponse("Category no found.");
            
            existingCategory.Patient = medicalHistory.Patient;
            existingCategory.Clinic = medicalHistory.Clinic;
            existingCategory.Diagnostics = medicalHistory.Diagnostics;

            try
            {
                _medicalHistoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new SaveMedicalHistoryResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new SaveMedicalHistoryResponse($"An error occurred while updating the category: {e.Message}");
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