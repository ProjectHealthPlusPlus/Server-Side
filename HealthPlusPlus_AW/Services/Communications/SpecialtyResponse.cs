using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
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