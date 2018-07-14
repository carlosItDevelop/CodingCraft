using Cooperchip.Common.Identity.Context;
using Cooperchip.Common.Identity.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Linq;

namespace Cooperchip.Common.Identity.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public static HttpContext HttpContext { get; private set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            const string nomecompleto = "Administrador do Sistema";
            const string usuario = "Administrador";
            const string email = "admin@admin.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";

            if (!context.Roles.Any(r => r.Name == roleName))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = roleName };
                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == usuario))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = usuario,
                    Usuario = usuario,
                    Email = email,
                    NomeCompleto = nomecompleto
                };

                manager.Create(user, password);
                manager.AddToRole(user.Id, roleName);
            }

            base.Seed(context);
        }
    }
}