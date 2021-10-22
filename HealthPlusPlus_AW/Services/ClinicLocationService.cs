using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Services
{
    public class ClinicLocationService : IClinicLocationService
    {
        private readonly IClinicLocationRepository _clinicLocationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClinicLocationService(IClinicLocationRepository clinicLocationRepository, IUnitOfWork unitOfWork)
        {
            _clinicLocationRepository = clinicLocationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ClinicLocation>> ListAsync()
        {
            return await _clinicLocationRepository.ListAsync();
        }

        public async Task<SaveClinicLocationResponse> SaveAsync(ClinicLocation clinicLocation)
        {
            try
            {
                await _clinicLocationRepository.AddAsync(clinicLocation);
                await _unitOfWork.CompleteAsync();

                return new SaveClinicLocationResponse(clinicLocation);
            }
            catch (Exception e)
            {
                return new SaveClinicLocationResponse($"An error occurred while saving: {e.Message}");
            }
        }

        public Task<SaveClinicLocationResponse> FindIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<SaveClinicLocationResponse> UpdateAsync(int id, ClinicLocation clinicLocation)
        {
            var existingCategory = await _clinicLocationRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new SaveClinicLocationResponse("Category no found.");
            
            existingCategory.Address = clinicLocation.Address;
            existingCategory.CapitalCity = clinicLocation.CapitalCity;
            existingCategory.Country = clinicLocation.Country;

            try
            {
                _clinicLocationRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new SaveClinicLocationResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new SaveClinicLocationResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<ClinicLocationResponse> DeleteAsync(int id)
        {
            var existingCategory = await _clinicLocationRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new ClinicLocationResponse("Category not found.");

            try
            {
                _clinicLocationRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new ClinicLocationResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new ClinicLocationResponse($"An error occurred while deleting category: {e.Message}");
            }
        }
    }
}