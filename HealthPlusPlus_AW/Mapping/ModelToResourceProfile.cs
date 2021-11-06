using AutoMapper;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Extensions;
using HealthPlusPlus_AW.Resources;

namespace HealthPlusPlus_AW.Mapping
{
    public class ModelToResourceProfile : Profile
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