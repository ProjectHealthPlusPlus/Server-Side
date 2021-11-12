using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
        {
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Patient>> ListAsync()
        {
            return await _patientRepository.ListAsync();
        }

        public async Task<PatientResponse> SaveAsync(Patient patient)
        {
            try
            {
                await _patientRepository.AddAsync(patient);
                await _unitOfWork.CompleteAsync();

                return new PatientResponse(patient);
            }
            catch (Exception e)
            {
                return new PatientResponse($"An error occurred while saving: {e.Message}");
            }
        }

        public async Task<PatientResponse> FindIdAsync(int id)
        {
            var existingCategory = await _patientRepository.FindIdAsync(id);
            try
            {
                _patientRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new PatientResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new PatientResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<PatientResponse> UpdateAsync(int id, Patient patient)
        {
            var existingCategory = await _patientRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new PatientResponse("Category no found.");
            
            existingCategory.Dni = patient.Dni;
            existingCategory.Name = patient.Name;
            existingCategory.Lastname = patient.Lastname;
            existingCategory.Age = patient.Age;

            try
            {
                _patientRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new PatientResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new PatientResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<PatientResponse> DeleteAsync(int id)
        {
            var existingCategory = await _patientRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new PatientResponse("Category not found.");

            try
            {
                _patientRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new PatientResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new PatientResponse($"An error occurred while deleting category: {e.Message}");
            }
        }
    }
}