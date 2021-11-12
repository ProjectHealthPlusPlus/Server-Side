using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Services
{
    public class DiagnosticService : IDiagnosticService
    {
        private readonly IDiagnosticRepository _diagnosticRepository;
        private readonly ISpecialtyRepository _specialtyRepository;
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DiagnosticService(IDiagnosticRepository diagnosticRepository, IUnitOfWork unitOfWork, ISpecialtyRepository specialtyRepository, IMedicalHistoryRepository medicalHistoryRepository)
        {
            _diagnosticRepository = diagnosticRepository;
            _unitOfWork = unitOfWork;
            _specialtyRepository = specialtyRepository;
            _medicalHistoryRepository = medicalHistoryRepository;
        }

        public async Task<IEnumerable<Diagnostic>> ListAsync()
        {
            return await _diagnosticRepository.ListAsync();
        }

        public async Task<IEnumerable<Diagnostic>> ListBySpecialtyIdAsync(int specialtyId)
        {
            return await _diagnosticRepository.FindBySpecialtyId(specialtyId);
        }

        public async Task<IEnumerable<Diagnostic>> ListByMedicalHistoryIdAsync(int medicalHistoryId)
        {
            return await _diagnosticRepository.FindByMedicalHistoryId(medicalHistoryId);
        }

        public async Task<DiagnosticResponse> SaveAsync(Diagnostic diagnostic)
        {
            var existingCategory = await _diagnosticRepository.FindIdAsync(diagnostic.SpecialtyId);

            if (existingCategory == null)
                return new DiagnosticResponse("Invalid Category.");

            var existingProductWithName = await _diagnosticRepository.FindByNameAsync(diagnostic.Description);

            if (existingProductWithName != null)
                return new DiagnosticResponse("Diagnostic Description already exits.");
            
            try
            {
                await _diagnosticRepository.AddAsync(diagnostic);
                await _unitOfWork.CompleteAsync();

                return new DiagnosticResponse(diagnostic);
            }
            catch (Exception e)
            {
                return new DiagnosticResponse($"An error occurred while saving: {e.Message}");
            }
        }

        public async Task<DiagnosticResponse> FindIdAsync(int id)
        {
            var existingCategory = await _diagnosticRepository.FindIdAsync(id);
            try
            {
                _diagnosticRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new DiagnosticResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new DiagnosticResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<DiagnosticResponse> UpdateAsync(int id, Diagnostic diagnostic)
        {
            var existingDiagnostic = await _diagnosticRepository.FindIdAsync(id);

            if (existingDiagnostic == null)
                return new DiagnosticResponse("Category no found.");
            
            var existingSpecialty = await _specialtyRepository.FindIdAsync(id);

            if (existingSpecialty == null)
                return new DiagnosticResponse("Specialty no found.");
            
            var existingMedicalHistory = await _medicalHistoryRepository.FindIdAsync(id);

            if (existingMedicalHistory == null)
                return new DiagnosticResponse("Medical History no found.");
            
            existingDiagnostic.PublishDate = diagnostic.PublishDate;
            existingDiagnostic.Description = diagnostic.Description;
            
            existingDiagnostic.SpecialtyId = diagnostic.SpecialtyId;
            existingDiagnostic.MedicalHistoryId = diagnostic.MedicalHistoryId;

            try
            {
                _diagnosticRepository.Update(existingDiagnostic);
                await _unitOfWork.CompleteAsync();

                return new DiagnosticResponse(existingDiagnostic);
            }
            catch (Exception e)
            {
                return new DiagnosticResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<DiagnosticResponse> DeleteAsync(int id)
        {
            var existingCategory = await _diagnosticRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new DiagnosticResponse("Category not found.");

            try
            {
                _diagnosticRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new DiagnosticResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new DiagnosticResponse($"An error occurred while deleting category: {e.Message}");
            }
        }
    }
}