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
        private readonly IUnitOfWork _unitOfWork;

        public DiagnosticService(IDiagnosticRepository diagnosticRepository, IUnitOfWork unitOfWork)
        {
            _diagnosticRepository = diagnosticRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Diagnostic>> ListAsync()
        {
            return await _diagnosticRepository.ListAsync();
        }

        public async Task<SaveDiagnosticResponse> SaveAsync(Diagnostic diagnostic)
        {
            try
            {
                await _diagnosticRepository.AddAsync(diagnostic);
                await _unitOfWork.CompleteAsync();

                return new SaveDiagnosticResponse(diagnostic);
            }
            catch (Exception e)
            {
                return new SaveDiagnosticResponse($"An error occurred while saving: {e.Message}");
            }
        }

        public async Task<SaveDiagnosticResponse> FindIdAsync(int id)
        {
            var existingCategory = await _diagnosticRepository.FindIdAsync(id);
            try
            {
                _diagnosticRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new SaveDiagnosticResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new SaveDiagnosticResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<SaveDiagnosticResponse> UpdateAsync(int id, Diagnostic diagnostic)
        {
            var existingCategory = await _diagnosticRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new SaveDiagnosticResponse("Category no found.");
            
            existingCategory.PublishDate = diagnostic.PublishDate;
            existingCategory.Description = diagnostic.Description;
            
            existingCategory.Specialty = diagnostic.Specialty;

            try
            {
                _diagnosticRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new SaveDiagnosticResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new SaveDiagnosticResponse($"An error occurred while updating the category: {e.Message}");
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