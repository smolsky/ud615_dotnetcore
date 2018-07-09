using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monolith.Auth
{
    public class JwtOptions
    {
        public const string ISSUER = "MyAuthServer"; // token issuer
        public const string AUDIENCE = "http://localhost:5000/"; // token consumer 
        const string KEY = "ud615_dotnetcore_secretkey!123";   // secret key
        public const int LIFETIME_MINUTES = 10; // 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
