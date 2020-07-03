using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wes.Estudos.BoasPraticas.WebApi.Configuration.AuthorizationConfig
{
    public class Policies
    {
        public const string Admin = "Admin";
        public const string User = "User";

        public static AuthorizationPolicy AdminPolicy() => new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Admin).Build();
        public static AuthorizationPolicy UserPolicy() => new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Admin, User).Build();
    }
}
