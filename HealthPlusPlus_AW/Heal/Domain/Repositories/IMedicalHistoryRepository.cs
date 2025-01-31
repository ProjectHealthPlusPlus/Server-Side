﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Heal.Domain.Models;

namespace HealthPlusPlus_AW.Heal.Domain.Repositories
{
    public interface IMedicalHistoryRepository
    {
        Task<IEnumerable<MedicalHistory>> ListAsync();
        Task AddAsync(MedicalHistory medicalHistory);
        Task<MedicalHistory> FindIdAsync(int id);
        Task<IEnumerable<MedicalHistory>> FindByPatientId(int patientId);
        Task<IEnumerable<MedicalHistory>> FindByClinicId(int clinicId);
        void Update(MedicalHistory medicalHistory);
        void Remove(MedicalHistory medicalHistory);
    }
}