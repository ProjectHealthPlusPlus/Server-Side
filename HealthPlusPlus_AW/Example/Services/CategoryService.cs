﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Example.Domain.Models;
using HealthPlusPlus_AW.Example.Domain.Repositories;
using HealthPlusPlus_AW.Example.Domain.Services;
using HealthPlusPlus_AW.Example.Services.Communications;
using HealthPlusPlus_AW.Shared.Domain.Repositories;

namespace HealthPlusPlus_AW.Example.Services
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

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(category);
            }
            catch (Exception e)
            {
                return new CategoryResponse($"An error occurred while saving: {e.Message}");
            }
        }

        public Task<CategoryResponse> FindIdAsync(int id)
        {
             throw new NotImplementedException();
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _categoryRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new CategoryResponse("Category no found.");

            existingCategory.Name = category.Name;

            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new CategoryResponse($"An error occurred while updating the category: {e.Message}");
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