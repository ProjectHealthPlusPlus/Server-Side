using System.Linq;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Security2.Authorization.Handlers.Interface;
using HealthPlusPlus_AW.Security2.Authorization.Settings;
using HealthPlusPlus_AW.Security2.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace HealthPlusPlus_AW.Security2.Authorization.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        
        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
            
        }

        public async Task Invoke(HttpContext context, IUserSecService userSecService, IJwtHandler handler)
        {
            var token = context.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split("").Last();
            
            var userId = handler.ValidateToken(token);
            
            if (userId != null)
                
                context.Items["Users"] = await userSecService.GetByIdAsync(userId.Value);
            
            await _next(context);
        }
    }
}