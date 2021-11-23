using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.meeting.Domain.Repositories;
using HealthPlusPlus_AW.Profile.Domain.Models;
using HealthPlusPlus_AW.Profile.Domain.Repositories;
using HealthPlusPlus_AW.Profile.Domain.Services;
using HealthPlusPlus_AW.Profile.Services.Communications;
using HealthPlusPlus_AW.Shared.Domain.Repositories;

namespace HealthPlusPlus_AW.Profile.Services
{
    public class ClinicService : IClinicService
    {
        private readonly IClinicRepository _clinicRepository;
        private readonly IClinicLocationRepository _clinicLocationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClinicService(IClinicRepository clinicRepository, IUnitOfWork unitOfWork, IClinicLocationRepository clinicLocationRepository)
        {
            _clinicRepository = clinicRepository;
            _unitOfWork = unitOfWork;
            _clinicLocationRepository = clinicLocationRepository;
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
            var existingClinic = await _clinicRepository.FindIdAsync(id);

            if (existingClinic == null)
                return new ClinicResponse("Category no found.");
            
            var existingClinicLocation = await _clinicLocationRepository.FindIdAsync(id);

            if (existingClinicLocation == null)
                return new ClinicResponse("Clinic Location no found.");
            
            existingClinic.Dni = clinic.Dni;
            existingClinic.Name = clinic.Name;
            existingClinic.Lastname = clinic.Lastname;
            existingClinic.Age = clinic.Age;
            
            existingClinic.ClinicLocationId = clinic.ClinicLocationId;
            
            try
            {
                _clinicRepository.Update(existingClinic);
                await _unitOfWork.CompleteAsync();

                return new ClinicResponse(existingClinic);
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