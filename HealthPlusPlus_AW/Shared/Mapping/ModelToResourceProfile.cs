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
using HealthPlusPlus_AW.Shared.Extensions;

namespace HealthPlusPlus_AW.Shared.Mapping
{
    public class ModelToResourceProfile : AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Product, ProductResource>()
                .ForMember(
                    target =>
                        target.UnitOfMeasurement,
                    options =>
                        options.MapFrom(source =>
                            source.UnitOfMeasurement.ToDescriptionString()));
            
            CreateMap<AppointmentDetails, AppointmentDetailsResource>();
            CreateMap<Appointment, AppointmentResource>();
            CreateMap<ClinicLocation, ClinicLocationResource>();
            CreateMap<Clinic, ClinicResource>();
            CreateMap<Diagnostic, DiagnosticResource>();

            CreateMap<Doctor, DoctorResource>();
            CreateMap<MedicalHistory, MedicalHistoryResource>();
            CreateMap<Patient, PatientResource>();
            CreateMap<Specialty, SpecialtyResource>();
            CreateMap<User, UserResource>();
        }
    }
}