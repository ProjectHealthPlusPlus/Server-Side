using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class SaveMedicalHistoryResponse : BaseResponse
    {
        public MedicalHistory Category { get; private set; }

        public SaveMedicalHistoryResponse(bool success, string message, MedicalHistory category) : base(success, message)
        {
            Category = category;
        }

        public SaveMedicalHistoryResponse(MedicalHistory medicalHistory) : this(true, string.Empty, medicalHistory){}
        
        public SaveMedicalHistoryResponse(string message) : this(false, message, null){}
    }
}