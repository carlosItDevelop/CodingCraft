using Cooperchip.Common.Identity.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Cooperchip.Common.Identity.Configuration
{
    // Configure the RoleManager used in the application. RoleManager is defined in the ASP.NET Identity core assembly
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleStore"></param>
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
        }
    }
}
