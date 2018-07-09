using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace monolith.Users
{
    public class UserIdentities
    {
        private static List<User> users= new List<User>
        {
            new User { Username="user", PasswordHash="AQAAAAEAACcQAAAAEDHlxKZy3l4eJkajU2bGs7o8l9F/8HGzWHvowrcqu4hJDLipE1hQnpy4THsn/Rz/gw==", Email="user@example.com"}
        };
        public static ClaimsIdentity GetIdentity(string login, string password)
        {
            var hasher = new PasswordHasher<User>();

            var user = users.FirstOrDefault(x => x.Username == login && 
              (hasher.VerifyHashedPassword(x,x.PasswordHash,password) != PasswordVerificationResult.Failed));
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                    new Claim("email", user.Email)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            
            return null;
        }
    }
}
