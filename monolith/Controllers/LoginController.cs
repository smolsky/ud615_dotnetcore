using idunno.Authentication.Basic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using monolith.Auth;
using monolith.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace monolith.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        [Authorize( AuthenticationSchemes = BasicAuthenticationDefaults.AuthenticationScheme)]
        [Route("login")]
        public IActionResult GetToken()
        {

            var tokenString = BuildToken(User.Identity as ClaimsIdentity);

            return Ok(new { token = tokenString });
        }

        private string BuildToken(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;
            // creating JWT-token
            var jwt = new JwtSecurityToken(
                    issuer: JwtOptions.ISSUER,
                    audience: JwtOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(JwtOptions.LIFETIME_MINUTES)),
                    signingCredentials: new SigningCredentials(JwtOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }
}
