using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
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