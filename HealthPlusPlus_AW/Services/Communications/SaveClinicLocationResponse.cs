using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class SaveClinicLocationResponse : BaseResponse

    {
    public ClinicLocation Clinic { get; private set; }

    public SaveClinicLocationResponse(bool success, string message, ClinicLocation clinic) : base(success, message)
    {
        Clinic = clinic;
    }

    public SaveClinicLocationResponse(ClinicLocation clinicLocation) : this(true, string.Empty, clinicLocation)
    {
    }

    public SaveClinicLocationResponse(string message) : this(false, message, null)
    {
    }
    }
}