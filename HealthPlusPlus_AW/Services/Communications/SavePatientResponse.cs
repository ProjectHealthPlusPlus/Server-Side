using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class SavePatientResponse : BaseResponse
    {
        public Patient Patient { get; private set; }

        public SavePatientResponse(bool success, string message, Patient patient) : base(success, message)
        {
            Patient = patient;
        }
        public SavePatientResponse(Patient patient) : this(true, string.Empty, patient){}
        
        public SavePatientResponse(string message) : this(false, message, null){}
    }
}