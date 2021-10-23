using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Services.Communications;

namespace HealthPlusPlus_AW.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorService(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork)
        {
            _doctorRepository = doctorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Doctor>> ListAsync()
        {
            return await _doctorRepository.ListAsync();
        }

        public async Task<SaveDoctorResponse> SaveAsync(Doctor doctor)
        {
            try
            {
                await _doctorRepository.AddAsync(doctor);
                await _unitOfWork.CompleteAsync();

                return new SaveDoctorResponse(doctor);
            }
            catch (Exception e)
            {
                return new SaveDoctorResponse($"An error occurred while saving: {e.Message}");
            }
        }

        public async Task<SaveDoctorResponse> FindIdAsync(int id)
        {
            var existingCategory = await _doctorRepository.FindIdAsync(id);
            try
            {
                _doctorRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new SaveDoctorResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new SaveDoctorResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<SaveDoctorResponse> UpdateAsync(int id, Doctor doctor)
        {
            var existingCategory = await _doctorRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new SaveDoctorResponse("Category no found.");
            
            existingCategory.Dni = doctor.Dni;
            existingCategory.Name = doctor.Name;
            existingCategory.Lastname = doctor.Lastname;
            existingCategory.Age = doctor.Age;
            
            existingCategory.Specialties = doctor.Specialties;
            existingCategory.Clinics = doctor.Clinics;
            
            try
            {
                _doctorRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new SaveDoctorResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new SaveDoctorResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<DoctorResponse> DeleteAsync(int id)
        {
            var existingCategory = await _doctorRepository.FindIdAsync(id);

            if (existingCategory == null)
                return new DoctorResponse("Category not found.");

            try
            {
                _doctorRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new DoctorResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new DoctorResponse($"An error occurred while deleting category: {e.Message}");
            }
        }
    }
}