using HealthPlusPlus_AW.Profile.Domain.Models;
using HealthPlusPlus_AW.Shared.Services.Communications;

namespace HealthPlusPlus_AW.Profile.Services.Communications
{
    public class PatientResponse : BaseResponse<Patient>
    {
        public PatientResponse(string message) : base(message)
        {
        }

        public PatientResponse(Patient patient) : base(patient)
        {
        }
    }
}