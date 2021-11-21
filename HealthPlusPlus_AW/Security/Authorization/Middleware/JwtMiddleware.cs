using System.Linq;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Security.Authorization.Handlers.Interface;
using HealthPlusPlus_AW.Security.Authorization.Settings;
using HealthPlusPlus_AW.Security.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace HealthPlusPlus_AW.Security.Authorization.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, AppSettings appSettings)
        {
            _next = next;
            _appSettings = appSettings;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtHandler handler)
        {
            var token = context.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split("").Last();
            var userId = handler.ValidateToken(token);
            if (userId != null)
                context.Items["Users"] = await userService.GetByIdAsync(userId.Value);
            await _next(context);
        }
    }
}