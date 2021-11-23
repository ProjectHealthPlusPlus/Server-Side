using AutoMapper;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Resources;
using HealthPlusPlus_AW.Security2.Domain.Models;
using HealthPlusPlus_AW.Security2.Domain.Services.Communication;
using HealthPlusPlus_AW.Security2.Resources;

namespace HealthPlusPlus_AW.Security2.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<UserSec, AuthenticateResponse>();
            
            CreateMap<UserSec, UserSecResource>();
        }
    }
}