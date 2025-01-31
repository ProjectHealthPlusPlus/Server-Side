﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.meeting.Domain.Models;
using HealthPlusPlus_AW.meeting.Domain.Repositories;
using HealthPlusPlus_AW.Shared.Persistance.Contexts;
using HealthPlusPlus_AW.Shared.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.meeting.Persistance
{
    public class ClinicLocationRepository : BaseRepository, IClinicLocationRepository
    {
        public ClinicLocationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ClinicLocation>> ListAsync()
        {
            return await _context.ClinicLocations.ToListAsync();
        }

        public async Task AddAsync(ClinicLocation clinicLocation)
        {
            await _context.ClinicLocations.AddAsync(clinicLocation);
        }

        public async Task<ClinicLocation> FindIdAsync(int id)
        {
            return await _context.ClinicLocations.FindAsync(id);
        }

        public void Update(ClinicLocation clinicLocation)
        {
            _context.ClinicLocations.Update(clinicLocation);
        }

        public void Remove(ClinicLocation clinicLocation)
        {
            _context.ClinicLocations.Remove(clinicLocation);
        }
    }
}