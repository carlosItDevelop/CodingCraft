using Cooperchip.Common.Identity.Configuration;
using Cooperchip.Common.Identity.Context;
using Cooperchip.Common.Identity.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;


namespace Cooperchip.Common.Identity.Services
{
    public static class UserServices
    {

        public static IEnumerable<ApplicationUser> ObterTodosOsUsuarios()
        {

            var result = new List<ApplicationUser>();
            using (var ctx = new ApplicationDbContext())
            {
                //var UserManager = new ApplicationUserManager();
                //var RoleManager = new ApplicationRoleManager();
                //result = ctx.ApplicationUsers.ToList();
            }

            return result;
        }
    }
}
