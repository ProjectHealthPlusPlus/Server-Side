﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Profile.Domain.Models;

namespace HealthPlusPlus_AW.Profile.Domain.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> ListAsync();
        Task AddAsync(Patient patient);
        Task<Patient> FindIdAsync(int id);
        void Update(Patient patient);
        void Remove(Patient patient);
    }
}