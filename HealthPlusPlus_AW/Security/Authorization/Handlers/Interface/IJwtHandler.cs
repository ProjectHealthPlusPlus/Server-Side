using HealthPlusPlus_AW.Security.Domain.Models;

namespace HealthPlusPlus_AW.Security.Authorization.Handlers.Interface
{
    public interface IJwtHandler
    {
        public string GenerateToken(UserSec user);
        public int? ValidateToken(string token);

    }
}