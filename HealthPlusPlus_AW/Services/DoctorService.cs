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
        private readonly ISpecialtyRepository _specialtyRepository;
        private readonly IClinicRepository _clinicRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorService(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork, IClinicRepository clinicRepository, ISpecialtyRepository specialtyRepository)
        {
            _doctorRepository = doctorRepository;
            _unitOfWork = unitOfWork;
            _clinicRepository = clinicRepository;
            _specialtyRepository = specialtyRepository;
        }

        public async Task<IEnumerable<Doctor>> ListAsync()
        {
            return await _doctorRepository.ListAsync();
        }

        public async Task<IEnumerable<Doctor>> ListBySpecialtyIdAsync(int specialtyId)
        {
            return await _doctorRepository.FindBySpecialtyId(specialtyId);
        }

        public async Task<IEnumerable<Doctor>> ListByClinicIdAsync(int clinicId)
        {
            return await _doctorRepository.FindByClinicId(clinicId);
        }

        public async Task<DoctorResponse> SaveAsync(Doctor doctor)
        {
            try
            {
                await _doctorRepository.AddAsync(doctor);
                await _unitOfWork.CompleteAsync();

                return new DoctorResponse(doctor);
            }
            catch (Exception e)
            {
                return new DoctorResponse($"An error occurred while saving: {e.Message}");
            }
        }

        public async Task<DoctorResponse> FindIdAsync(int id)
        {
            var existingCategory = await _doctorRepository.FindIdAsync(id);
            try
            {
                _doctorRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new DoctorResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new DoctorResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<DoctorResponse> UpdateAsync(int id, Doctor doctor)
        {
            var existingDoctor = await _doctorRepository.FindIdAsync(id);

            if (existingDoctor == null)
                return new DoctorResponse("Doctor no found.");
            
            var existingSpecialty = await _doctorRepository.FindIdAsync(id);

            if (existingSpecialty == null)
                return new DoctorResponse("Specialty no found.");
            
            var existingClinic = await _clinicRepository.FindIdAsync(id);

            if (existingClinic == null)
                return new DoctorResponse("Clinic no found.");
            
            existingDoctor.Dni = doctor.Dni;
            existingDoctor.Name = doctor.Name;
            existingDoctor.Lastname = doctor.Lastname;
            existingDoctor.Age = doctor.Age;

            existingDoctor.SpecialtyId = doctor.SpecialtyId;
            existingDoctor.ClinicId = doctor.ClinicId;
            
            try
            {
                _doctorRepository.Update(existingDoctor);
                await _unitOfWork.CompleteAsync();

                return new DoctorResponse(existingDoctor);
            }
            catch (Exception e)
            {
                return new DoctorResponse($"An error occurred while updating the category: {e.Message}");
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