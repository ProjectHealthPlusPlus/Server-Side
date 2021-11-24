using HealthPlusPlus_AW.Profile.Domain.Repositories;
using HealthPlusPlus_AW.Shared.Services.Communications;

namespace HealthPlusPlus_AW.Profile.Services.Communications
{
    public class UserResponse : BaseResponse<User>
    {
        public UserResponse(string message) : base(message)
        {
        }

        public UserResponse(User user) : base(user)
        {
        }
    }
}