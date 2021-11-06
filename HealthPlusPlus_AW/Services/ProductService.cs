using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }

        public async Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId)
        {
            return await _productRepository.FindByCategoryId(categoryId);
        }

        public async Task<ProductResponse> SaveAsync(Product product)
        { 
            var existingCategory = await _productRepository.FindIdAsync(product.CategoryId);

            if (existingCategory == null)
                return new ProductResponse("Invalid Category.");

            var existingProductWithDescription = await _productRepository.FindByNameAsync(product.Name);

            if (existingProductWithDescription != null)
                return new ProductResponse("Product Name already exits.");
            
            try
            {
                await _productRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(product);
            }
            catch (Exception e)
            {
                return new ProductResponse($"An error occurred while saving: {e.Message}");
            }
        }

        public async Task<ProductResponse> UpdateAsync(int id, Product product)
        {
            var existingProduct = await _productRepository.FindIdAsync(id);

            if (existingProduct == null)
                return new ProductResponse("Product no found.");

            var existingCategory = await _categoryRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new ProductResponse("Category no found.");
            
            // var existingProductWithName = await _productRepository.FindByNameAsync(product.Name);
            //
            // if (existingProductWithName != null && existingProductWithName.Id != existingProduct.Id)
            //     return new ProductResponse("Product Name already exits.");
            
            existingProduct.Name = product.Name;
            existingProduct.UnitOfMeasurement = product.UnitOfMeasurement;
            existingProduct.QuantityPackage = product.QuantityPackage;
            existingProduct.CategoryId = product.CategoryId;
            
            try
            {
                _productRepository.Update(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(existingProduct);
            }
            catch (Exception e)
            {
                return new ProductResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<ProductResponse> DeleteAsync(int id)
        {
            var existingProduct = await _productRepository.FindIdAsync(id);

            if (existingProduct == null)
                return new ProductResponse("Category not found.");

            try
            {
                _productRepository.Remove(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(existingProduct);
            }
            catch (Exception e)
            {
                return new ProductResponse($"An error occurred while deleting category: {e.Message}");
            }
        }
    }
}