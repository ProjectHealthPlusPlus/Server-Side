using HealthPlusPlus_AW.Security2.Domain.Models;

namespace HealthPlusPlus_AW.Security2.Authorization.Handlers.Interface
{
    public interface IJwtHandler
    {
        public string GenerateToken(UserSec user);
        public int? ValidateToken(string token);

    }
}