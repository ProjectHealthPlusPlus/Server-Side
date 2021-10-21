using HealthPlusPlus_AW.Domain.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class SaveSpecialtyResponse : BaseResponse
    {
        public Specialty Specialty { get; private set; }

        public SaveSpecialtyResponse(bool success, string message, Specialty specialty) : base(success, message)
        {
            Specialty = specialty;
        }
        
        public SaveSpecialtyResponse(Specialty specialty) : this(true, string.Empty, specialty){}
        public SaveSpecialtyResponse(string message) : this(false, message, null){}

    }
}