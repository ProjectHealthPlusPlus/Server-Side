using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class MedicalHistoryResponse : BaseResponse<MedicalHistory>
    {
        public MedicalHistoryResponse(string message) : base(message)
        {
        }

        public MedicalHistoryResponse(MedicalHistory medicalHistory) : base(medicalHistory)
        {
        }
    }
}