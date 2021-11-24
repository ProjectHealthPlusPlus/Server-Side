using HealthPlusPlus_AW.Heal.Domain.Models;
using HealthPlusPlus_AW.Shared.Services.Communications;

namespace HealthPlusPlus_AW.Heal.Services.Communications
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