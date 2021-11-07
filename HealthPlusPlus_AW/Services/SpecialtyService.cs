using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Services
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SpecialtyService(ISpecialtyRepository specialtyRepository, IUnitOfWork unitOfWork)
        {
            _specialtyRepository = specialtyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Specialty>> ListAsync()
        {
            return await _specialtyRepository.ListAsync();
        }

        public async Task<SpecialtyResponse> SaveAsync(Specialty specialty)
        {
            try
            {
                await _specialtyRepository.AddAsync(specialty);
                await _unitOfWork.CompleteAsync();

                return new SpecialtyResponse(specialty);
            }
            catch (Exception e)
            {
                return new SpecialtyResponse($"An error ocurred while saving: {e.Message}");
            }
        }

        public async Task<SpecialtyResponse> FindIdAsync(int id)
        {
            var existingCategory = await _specialtyRepository.FindIdAsync(id);
            try
            {
                _specialtyRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new SpecialtyResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new SpecialtyResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<SpecialtyResponse> UpdateAsync(int id, Specialty specialty)
        {
            var existingCategory = await _specialtyRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new SpecialtyResponse("Category no found.");

            existingCategory.Name = specialty.Name;
            existingCategory.Description = specialty.Description;

            try
            {
                _specialtyRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new SpecialtyResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new SpecialtyResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<SpecialtyResponse> DeleteAsync(int id)
        {
            var existingCategory = await _specialtyRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new SpecialtyResponse("Category not found.");

            try
            {
                _specialtyRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new SpecialtyResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new SpecialtyResponse($"An error occurred while deleting category: {e.Message}");
            }
        }
    }
}