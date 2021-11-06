using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Services
{
    public class ClinicService : IClinicService
    {
        private readonly IClinicRepository _clinicRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClinicService(IClinicRepository clinicRepository, IUnitOfWork unitOfWork)
        {
            _clinicRepository = clinicRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Clinic>> ListAsync()
        {
            return await _clinicRepository.ListAsync();
        }

        public async Task<IEnumerable<Clinic>> ListByClinicLocationIdAsync(int clinicLocationId)
        {
            return await _clinicRepository.FindByClinicLocationId(clinicLocationId);
        }

        public async Task<ClinicResponse> SaveAsync(Clinic clinic)
        {
            try
            {
                await _clinicRepository.AddAsync(clinic);
                await _unitOfWork.CompleteAsync();

                return new ClinicResponse(clinic);
            }
            catch (Exception e)
            {
                return new ClinicResponse($"An error occurred while saving: {e.Message}");
            }
        }

        public async Task<ClinicResponse> FindIdAsync(int id)
        {
            var existingCategory = await _clinicRepository.FindIdAsync(id);
            try
            {
                _clinicRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new ClinicResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new ClinicResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<ClinicResponse> UpdateAsync(int id, Clinic clinic)
        {
            var existingCategory = await _clinicRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new ClinicResponse("Category no found.");
            
            existingCategory.Dni = clinic.Dni;
            existingCategory.Name = clinic.Name;
            existingCategory.Lastname = clinic.Lastname;
            existingCategory.Age = clinic.Age;
            
            existingCategory.ClinicLocation = clinic.ClinicLocation;
            existingCategory.MedicalHistories = clinic.MedicalHistories;

            try
            {
                _clinicRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new ClinicResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new ClinicResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<ClinicResponse> DeleteAsync(int id)
        {
            var existingCategory = await _clinicRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new ClinicResponse("Category not found.");

            try
            {
                _clinicRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new ClinicResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new ClinicResponse($"An error occurred while deleting category: {e.Message}");
            }
        }
    }
}