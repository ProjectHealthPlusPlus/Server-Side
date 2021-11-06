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
            CreateMap<SaveProductResource, Product>()
                .ForMember(target =>
                        target.UnitOfMeasurement,
                    options =>
                        options.MapFrom(source =>
                            (EUnitOfMeasurement)source.UnitOfMeasurement));

            CreateMap<SaveAppointmentDetailsResource, AppointmentDetails>();
            CreateMap<SaveAppointmentResource, Appointment>();
            CreateMap<SaveClinicLocationResource, ClinicLocation>();
            CreateMap<SaveClinicResource, Clinic>();
            CreateMap<SaveDiagnosticResource, Diagnostic>();
            
            CreateMap<SaveDoctorResource, Doctor>();
            CreateMap<SaveMedicalHistoryResource, MedicalHistory>();
            CreateMap<SavePatientResource, Patient>();
            
            CreateMap<SaveSpecialtyResource, Specialty>();
            CreateMap<SaveUserResource, User>();
        }
    }
}