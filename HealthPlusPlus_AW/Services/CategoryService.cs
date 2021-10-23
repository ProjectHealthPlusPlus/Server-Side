using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        public async Task<SaveCategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new SaveCategoryResponse(category);
            }
            catch (Exception e)
            {
                return new SaveCategoryResponse($"An error occurred while saving: {e.Message}");
            }
        }

        public Task<SaveCategoryResponse> FindIdAsync(int id)
        {
             throw new NotImplementedException();
        }

        public async Task<SaveCategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _categoryRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new SaveCategoryResponse("Category no found.");

            existingCategory.Name = category.Name;

            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new SaveCategoryResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new SaveCategoryResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new CategoryResponse("Category not found.");

            try
            {
                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new CategoryResponse($"An error occurred while deleting category: {e.Message}");
            }
        }
    }
}