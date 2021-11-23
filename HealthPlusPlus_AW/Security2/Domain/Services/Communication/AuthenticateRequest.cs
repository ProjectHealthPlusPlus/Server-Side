using System.ComponentModel.DataAnnotations;

namespace HealthPlusPlus_AW.Security2.Domain.Services.Communication
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}