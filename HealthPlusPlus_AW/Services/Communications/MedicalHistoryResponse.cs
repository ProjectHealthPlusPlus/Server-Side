using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class MedicalHistoryResponse : BaseResponse
    {
        public MedicalHistory MedicalHistory { get; private set; }

        public MedicalHistoryResponse(bool success, string message, MedicalHistory medicalHistory) : base(success, message)
        {
            MedicalHistory = medicalHistory;
        }

        public MedicalHistoryResponse(MedicalHistory medicalHistory) : this(true, string.Empty, medicalHistory){}
        
        public MedicalHistoryResponse(string message) : this(false, message, null){}
    }
}