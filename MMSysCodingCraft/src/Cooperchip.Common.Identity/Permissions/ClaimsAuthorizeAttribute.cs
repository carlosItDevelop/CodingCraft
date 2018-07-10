using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNetInterop.UI.MVC5.Permissions
{
    public class ClaimsAcessoAttribute : AuthorizeAttribute
    {
        private readonly string _claimName;
        private readonly string _claimValue;

        public ClaimsAcessoAttribute(string claimName, string claimValue)
        {
            _claimName = claimName;
            _claimValue = claimValue;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            var userClaims = HttpContext.Current.User as ClaimsPrincipal;

            //var userClaims = Services.GetClaimsFixas(user);

            if  (userClaims.Claims.Where(c => c.Type == _claimName)
                    .Any(x => x.Value.Contains(_claimValue))
                || (
                        userClaims.IsInRole("Admin") || userClaims.IsInRole("SuperAdmin")
                   )
                )

            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                                  new RouteValueDictionary
                                   {
                                         { "action", "AcessoNegado" },
                                         { "controller", "Home" }
                                   });
            }
        }
    }
}