using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Security2.Authorization.Handlers.Interface;
using HealthPlusPlus_AW.Security2.Domain.Models;
using HealthPlusPlus_AW.Security2.Domain.Repositories;
using HealthPlusPlus_AW.Security2.Domain.Services;
using HealthPlusPlus_AW.Security2.Domain.Services.Communication;
using HealthPlusPlus_AW.Security2.Exceptions;
using BCryptNet = BCrypt.Net.BCrypt;

namespace HealthPlusPlus_AW.Security2.Services
{
    public class UserSecService : IUserSecService
    {
        private readonly IUserSecRepository _userSecRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;
        
        public UserSecService(IJwtHandler jwtHandler, IUnitOfWork unitOfWork, IUserSecRepository userSecRepository, IMapper mapper)
        {
            _jwtHandler = jwtHandler;
            _unitOfWork = unitOfWork;
            _userSecRepository = userSecRepository;
            _mapper = mapper;
        }
        
        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            var user = await _userSecRepository.FindUsernameAsync(request.Username);
            
            // Validate
            if (user == null || !BCryptNet.Verify(request.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect.");
            
            // Authentication successful
            var response = _mapper.Map<AuthenticateResponse>(user);
            response.JwtToken = _jwtHandler.GenerateToken(user);
            return response;
        }

        public async Task<IEnumerable<UserSec>> ListAsync()
        {
            return await _userSecRepository.ListAsync();
        }

        public async Task<UserSec> GetByIdAsync(int id)
        {
            var user = await _userSecRepository.FindIdAsync(id);
            if (user == null) throw new KeyNotFoundException("User not found.");
            return user;
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            // Validate
            if (_userSecRepository.ExistByUsername(request.Username))
                throw new AppException($"Username {request.Username} is already taken.");
            
            // Map request to User object
            var user = _mapper.Map<UserSec>(request);
            
            // Hash password
            user.PasswordHash = BCryptNet.HashPassword(request.Password);
            
            // Save User

            try
            {
                await _userSecRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while saving the user: {e.Message}");
            }
        }

        public async Task UpdateAsync(int id, UpdateRequest request)
        {
            var user = GetById(id);
            
            // Validate
            if (_userSecRepository.ExistByUsername(request.Username))
                throw new AppException($"Username {request.Username} is already taken.");

            // Hash password if entered
            if (!string.IsNullOrEmpty(request.Password))
                user.PasswordHash = BCryptNet.HashPassword(request.Password);
            
            // Map request to User object

            _mapper.Map(request, user);
            
            // Save User

            try
            {
                _userSecRepository.Update(user);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while updating the user: {e.Message}");
            }

        }

        public async Task DeleteAsync(int id)
        {
            var user = GetById(id);
            
            // Delete User
            try
            {
                _userSecRepository.Remove(user);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while deleting the user: {e.Message}");
            }
        }
        
        // Helpers
        private UserSec GetById(int id)
        {
            var user = _userSecRepository.FindId(id);
            if (user == null) throw new KeyNotFoundException("User not found.");
            return user;
        }
    }
}