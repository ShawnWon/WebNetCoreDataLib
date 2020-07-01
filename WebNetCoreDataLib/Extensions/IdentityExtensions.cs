using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace WebNetCoreDataLib.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetUserGUID(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("userGUID");
            return (claim != null) ? claim.Value : string.Empty;
        
        }

        public static void SwitchInstitute(this IIdentity identity, int targetInstituteId)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("CurrentInstitutionID");

            if (claim != null)
            {
                var Ident = identity as ClaimsIdentity;
                Ident.RemoveClaim(Ident.FindFirst("CurrentInstitutionID"));

                Ident.
                   AddClaims(new[]
                   {
                new Claim("CurrentInstitutionID",
                targetInstituteId.ToString())
                    });
            }
        }
    }
}
