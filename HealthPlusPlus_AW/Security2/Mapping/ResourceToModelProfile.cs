using AutoMapper;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Security2.Domain.Models;
using HealthPlusPlus_AW.Security2.Domain.Services.Communication;

namespace HealthPlusPlus_AW.Security2.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<RegisterRequest, UserSec>();
            
            CreateMap<UpdateRequest, UserSec>()
                .ForAllMembers(options => options.Condition(
                    (source, target, property) =>
                    {
                        if (property == null) return false;
                        if (property.GetType() == typeof(string) &&
                            string.IsNullOrEmpty((string)property)) return false;
                        return true;
                    }
                    ));
        }
    }
}