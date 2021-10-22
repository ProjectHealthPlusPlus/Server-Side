using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class SpecialtyResponse : BaseResponse
    {
        public Specialty Specialty { get; private set; }

        public SpecialtyResponse(bool success, string message, Specialty specialty) : base(success, message)
        {
            Specialty = specialty;
        }

        public SpecialtyResponse(Specialty specialty) : this(true, string.Empty, specialty){}
        
        public SpecialtyResponse(string message) : this(false, message, null){}
    }
}