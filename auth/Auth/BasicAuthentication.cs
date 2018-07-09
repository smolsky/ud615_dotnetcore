using idunno.Authentication.Basic;
using monolith.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace monolith.Auth
{
    public class BasicAuthentication
    {
        public static void Configure(BasicAuthenticationOptions options)
        {
            options.Realm = "idunno";
            options.AllowInsecureProtocol = true;
            options.Events = new BasicAuthenticationEvents
            {
                OnValidateCredentials = context =>
                {
                    var identity = UserIdentities.GetIdentity(context.Username, context.Password);

                    if(identity!= null)
                    {
                        context.Principal = new ClaimsPrincipal(identity);
                        context.Success();
                    }

                    return Task.CompletedTask;
                }
            };
        }
    }
}
