using AutoMapper;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Resources;

namespace HealthPlusPlus_AW.Mapping
{
    public class ResourceToModelProfile :  Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
            
            CreateMap<AppointmentDetailsResource, AppointmentDetails>();
            CreateMap<AppointmentResource, Appointment>();
            CreateMap<ClinicLocationResource, ClinicLocation>();
            CreateMap<ClinicResource, Clinic>();
            CreateMap<DiagnosticResource, Diagnostic>();
            CreateMap<DoctorResource, Doctor>();
            CreateMap<MedicalHistoryResource, MedicalHistory>();
            CreateMap<PatientResource, Patient>();
            CreateMap<SaveSpecialtyResource, Specialty>();
            CreateMap<SaveUserResource, User>();
        }
    }
}