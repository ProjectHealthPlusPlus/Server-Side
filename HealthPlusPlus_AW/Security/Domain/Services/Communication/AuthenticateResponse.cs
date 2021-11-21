namespace HealthPlusPlus_AW.Security.Domain.Services.Communication
{
    public class AuthenticateResponse
    {
        public int Int { get; set;  }
        public string FirstName { get; set;  }
        public string LastName { get; set;  }
        public string Username { get; set;  }
        public string JwtToken { get; set;  }
    }
}