using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class DoctorResponse : BaseResponse

    {
    public Doctor Doctor { get; private set; }

    public DoctorResponse(bool success, string message, Doctor doctor) : base(success, message)
    {
        Doctor = doctor;
    }

    public DoctorResponse(Doctor doctor) : this(true, string.Empty, doctor)
    {
    }

    public DoctorResponse(string message) : this(false, message, null)
    {
    }
    }
}