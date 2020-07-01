using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using WebNetCoreDataLib.Models;
using Microsoft.Extensions.Options;

namespace WebNetCoreDataLib.Claims
{
    public class WNCClaimsPrincipalFactory: UserClaimsPrincipalFactory<ApplicationUser>
    {
        public WNCClaimsPrincipalFactory(
           UserManager<ApplicationUser> userManager,
           IOptions<IdentityOptions> optionsAccessor) :
              base(userManager, optionsAccessor)
        {
        }

        public async override Task<ClaimsPrincipal>
           CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);

            // Add your claims here
            ((ClaimsIdentity)principal.Identity).
               AddClaims(new[]
               {
                new Claim("UserID",
                user.Id.ToString())
                });
            ((ClaimsIdentity)principal.Identity).
               AddClaims(new[]
               {
                new Claim("UserName",
                user.UserName.ToString())
                });
            ((ClaimsIdentity)principal.Identity).
               AddClaims(new[]
               {
                new Claim("Email",
                user.Email.ToString())
                });


            ((ClaimsIdentity)principal.Identity).
               AddClaims(new[]
               {
                new Claim("UserGUID",
                user.UserGUID.ToString())
                });

            ((ClaimsIdentity)principal.Identity).
               AddClaims(new[]
               {
                new Claim("CurrentInstitutionID",
                user.DefaultInstituteId.ToString())
                });

            return principal;
        }
    }
}
