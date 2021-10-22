using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class ClinicLocationResponse : BaseResponse
    {
        public ClinicLocation Clinic { get; private set; }

        public ClinicLocationResponse(bool success, string message, ClinicLocation clinic) : base(success, message)
        {
            Clinic = clinic;
        }

        public ClinicLocationResponse(ClinicLocation clinicLocation) : this(true, string.Empty, clinicLocation)
        {
        }

        public ClinicLocationResponse(string message) : this(false, message, null)
        {
        }
    }
}