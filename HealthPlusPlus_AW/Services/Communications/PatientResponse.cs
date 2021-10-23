using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class PatientResponse : BaseResponse
    {
        public Patient Patient { get; private set; }

        public PatientResponse(bool success, string message, Patient patient) : base(success, message)
        {
            Patient = patient;
        }
        public PatientResponse(Patient patient) : this(true, string.Empty, patient){}
        
        public PatientResponse(string message) : this(false, message, null){}
    }
}