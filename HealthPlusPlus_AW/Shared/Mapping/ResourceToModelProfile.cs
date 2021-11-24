using AutoMapper;
using HealthPlusPlus_AW.Example.Domain.Models;
using HealthPlusPlus_AW.Example.Resources;
using HealthPlusPlus_AW.Heal.Domain.Models;
using HealthPlusPlus_AW.Heal.Resource;
using HealthPlusPlus_AW.meeting.Domain.Models;
using HealthPlusPlus_AW.meeting.Resource;
using HealthPlusPlus_AW.Profile.Domain.Models;
using HealthPlusPlus_AW.Profile.Domain.Repositories;
using HealthPlusPlus_AW.Profile.Resource;

namespace HealthPlusPlus_AW.Shared.Mapping
{
    public class ResourceToModelProfile :  AutoMapper.Profile
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