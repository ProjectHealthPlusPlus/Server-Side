using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error ocurred while saving: {e.Message}");
            }
        }

        public async Task<UserResponse> FindIdAsync(int id)
        {
            var existingCategory = await _userRepository.FindIdAsync(id);
            try
            {
                _userRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existingCategory = await _userRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new UserResponse("Category no found.");

            existingCategory.Dni = user.Dni;
            existingCategory.Name = user.Name;
            existingCategory.Lastname = user.Lastname;
            existingCategory.Age = user.Age;
            
            try
            {
                _userRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingCategory = await _userRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new UserResponse("Category not found.");

            try
            {
                _userRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred while deleting category: {e.Message}");
            }
        }
    }
}