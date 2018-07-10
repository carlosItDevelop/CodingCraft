using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Cooperchip.Common.Identity.Services
{
    public static class Services
    {
        public static ClaimsPrincipal GetClaimsFixas(ClaimsPrincipal user)
        {
            Claim UsuarioPais = new Claim(ClaimTypes.Country, "Brasil");
            IList<Claim> claims = new List<Claim>() {
                        UsuarioPais
                    };

            ClaimsPrincipal currentPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;
            var claimsCollection = new Collection<Claim>();

            foreach (Claim ci in currentPrincipal.Claims)
            {
                claims.Add(ci);
            }

            
            ClaimsIdentity identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie, user.Identity.GetUserName(), ClaimTypes.Role);

            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            Thread.CurrentPrincipal = principal;

            return principal;

        }
    }
}
