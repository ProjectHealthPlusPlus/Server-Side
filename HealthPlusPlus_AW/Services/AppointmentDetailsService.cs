using System.Collections.Generic;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;

namespace HealthPlusPlus_AW.Services
{
    public class AppointmentDetailsService : IAppointmentDetailsService
    {
        private readonly IAppointmentDetailsRepository _appointmentDetailsRepository;

        public AppointmentDetailsService(IAppointmentDetailsRepository appointmentDetailsRepository)
        {
            _appointmentDetailsRepository = appointmentDetailsRepository;
        }

        public async Task<IEnumerable<AppointmentDetails>> ListAsync()
        {
            return await _appointmentDetailsRepository.ListAsync();
        }
    }
}