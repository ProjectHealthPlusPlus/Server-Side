using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;

namespace HealthPlusPlus_AW.Services
{
    public class ClinicLocationService : IClinicLocationService
    {
        private readonly IClinicLocationRepository _clinicLocationRepository;

        public ClinicLocationService(IClinicLocationRepository clinicLocationRepository)
        {
            _clinicLocationRepository = clinicLocationRepository;
        }

        public async Task<IEnumerable<ClinicLocation>> ListAsync()
        {
            return await _clinicLocationRepository.ListAsync();
        }
    }
}