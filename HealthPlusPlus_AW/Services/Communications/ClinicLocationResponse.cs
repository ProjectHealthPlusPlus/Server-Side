using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class ClinicLocationResponse : BaseResponse
    {
        public ClinicLocation ClinicLocation { get; private set; }

        public ClinicLocationResponse(bool success, string message, ClinicLocation clinicLocation) : base(success, message)
        {
            ClinicLocation = clinicLocation;
        }

        public ClinicLocationResponse(ClinicLocation clinicLocation) : this(true, string.Empty, clinicLocation)
        {
        }

        public ClinicLocationResponse(string message) : this(false, message, null)
        {
        }
    }
}