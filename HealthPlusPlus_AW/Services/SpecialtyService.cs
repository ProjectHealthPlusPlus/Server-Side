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

        public async Task<SaveSpecialtyResponse> SaveAsync(Specialty specialty)
        {
            try
            {
                await _specialtyRepository.AddAsync(specialty);
                await _unitOfWork.CompleteAsync();

                return new SaveSpecialtyResponse(specialty);
            }
            catch (Exception e)
            {
                return new SaveSpecialtyResponse($"An error ocurred while saving: {e.Message}");
            }
        }
    }
}