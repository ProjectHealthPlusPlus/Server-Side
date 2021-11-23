using Newtonsoft.Json;

namespace HealthPlusPlus_AW.Security2.Domain.Models
{
    public class UserSec
    {
        public int Id { get; set;  }
        public string FirstName { get; set;  }
        public string LastName { get; set;  }
        public string Username { get; set;  }
        [JsonIgnore]
        public string PasswordHash { get; set;  }
    }
}