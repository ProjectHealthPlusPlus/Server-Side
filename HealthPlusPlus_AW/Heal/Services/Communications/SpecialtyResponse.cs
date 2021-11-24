using HealthPlusPlus_AW.Heal.Domain.Models;
using HealthPlusPlus_AW.Shared.Services.Communications;

namespace HealthPlusPlus_AW.Heal.Services.Communications
{
    public class SpecialtyResponse : BaseResponse<Specialty>
    {
        public SpecialtyResponse(string message) : base(message)
        {
        }

        public SpecialtyResponse(Specialty specialty) : base(specialty)
        {
        }
    }
}