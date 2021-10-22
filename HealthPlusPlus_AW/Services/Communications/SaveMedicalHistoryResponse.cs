using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class SaveMedicalHistoryResponse : BaseResponse
    {
        public MedicalHistory MedicalHistory { get; private set; }

        public SaveMedicalHistoryResponse(bool success, string message, MedicalHistory medicalHistory) : base(success, message)
        {
            MedicalHistory = medicalHistory;
        }

        public SaveMedicalHistoryResponse(MedicalHistory medicalHistory) : this(true, string.Empty, medicalHistory){}
        
        public SaveMedicalHistoryResponse(string message) : this(false, message, null){}
    }
}