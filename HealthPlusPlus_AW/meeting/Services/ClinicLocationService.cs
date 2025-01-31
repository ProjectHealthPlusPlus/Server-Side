﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.meeting.Domain.Models;
using HealthPlusPlus_AW.meeting.Domain.Repositories;
using HealthPlusPlus_AW.meeting.Domain.Services;
using HealthPlusPlus_AW.meeting.Services.Communications;
using HealthPlusPlus_AW.Shared.Domain.Repositories;

namespace HealthPlusPlus_AW.meeting.Services
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

        public async Task<ClinicLocationResponse> SaveAsync(ClinicLocation clinicLocation)
        {
            try
            {
                await _clinicLocationRepository.AddAsync(clinicLocation);
                await _unitOfWork.CompleteAsync();

                return new ClinicLocationResponse(clinicLocation);
            }
            catch (Exception e)
            {
                return new ClinicLocationResponse($"An error occurred while saving: {e.Message}");
            }
        }

        public async Task<ClinicLocationResponse> FindIdAsync(int id)
        {
            var existingCategory = await _clinicLocationRepository.FindIdAsync(id);
            try
            {
                _clinicLocationRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new ClinicLocationResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new ClinicLocationResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<ClinicLocationResponse> UpdateAsync(int id, ClinicLocation clinicLocation)
        {
            var existingCategory = await _clinicLocationRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new ClinicLocationResponse("Category no found.");
            
            existingCategory.Address = clinicLocation.Address;
            existingCategory.CapitalCity = clinicLocation.CapitalCity;
            existingCategory.Country = clinicLocation.Country;

            try
            {
                _clinicLocationRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new ClinicLocationResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new ClinicLocationResponse($"An error occurred while updating the category: {e.Message}");
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