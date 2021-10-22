using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class ClinicResponse : BaseResponse

    {
    public Clinic Clinic { get; private set; }

    public ClinicResponse(bool success, string message, Clinic clinic) : base(success, message)
    {
        Clinic = clinic;
    }

    public ClinicResponse(Clinic clinic) : this(true, string.Empty, clinic)
    {
    }

    public ClinicResponse(string message) : this(false, message, null){}
    }
}