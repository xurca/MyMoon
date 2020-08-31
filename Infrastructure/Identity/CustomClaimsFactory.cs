﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MyMoon.Domain.UserManagement;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyMoon.Infrastructure.Identity
{
    public class CustomClaimsFactory : UserClaimsPrincipalFactory<User>
    {
        public CustomClaimsFactory(
            UserManager<User> userManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("firstname", user.FirstName));
            identity.AddClaim(new Claim("lastname", user.LastName));

            return identity;
        }
    }
}
