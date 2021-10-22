using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class SaveClinicResponse : BaseResponse

    {
    public Clinic Clinic { get; private set; }

    public SaveClinicResponse(bool success, string message, Clinic clinic) : base(success, message)
    {
        Clinic = clinic;
    }

    public SaveClinicResponse(Clinic clinic) : this(true, string.Empty, clinic)
    {
    }

    public SaveClinicResponse(string message) : this(false, message, null)
    {
    }
    }
}