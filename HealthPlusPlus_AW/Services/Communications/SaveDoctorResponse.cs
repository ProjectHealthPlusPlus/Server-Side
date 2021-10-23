using HealthPlusPlus_AW.Domain.Models;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class SaveDoctorResponse : BaseResponse
    {
        public Doctor Doctor { get; private set; }

        public SaveDoctorResponse(bool success, string message, Doctor doctor) : base(success, message)
        {
            Doctor = doctor;
        }

        public SaveDoctorResponse(Doctor doctor) : this(true, string.Empty, doctor){}
        
        public SaveDoctorResponse(string message) : this(false, message, null){}
    }
}