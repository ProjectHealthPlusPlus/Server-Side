using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class SaveClinicLocationResponse : BaseResponse

    {
    public ClinicLocation ClinicLocation { get; private set; }

    public SaveClinicLocationResponse(bool success, string message, ClinicLocation clinicLocation) : base(success, message)
    {
        ClinicLocation = clinicLocation;
    }

    public SaveClinicLocationResponse(ClinicLocation clinicLocation) : this(true, string.Empty, clinicLocation)
    {
    }

    public SaveClinicLocationResponse(string message) : this(false, message, null)
    {
    }
    }
}