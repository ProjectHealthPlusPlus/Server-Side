using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class MedicalHistoryResponse : BaseResponse
    {
        public MedicalHistory Category { get; private set; }

        public MedicalHistoryResponse(bool success, string message, MedicalHistory category) : base(success, message)
        {
            Category = category;
        }

        public MedicalHistoryResponse(MedicalHistory medicalHistory) : this(true, string.Empty, medicalHistory){}
        
        public MedicalHistoryResponse(string message) : this(false, message, null){}
    }
}