using System.ComponentModel.DataAnnotations;

namespace HealthPlusPlus_AW.Services.Communications
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}