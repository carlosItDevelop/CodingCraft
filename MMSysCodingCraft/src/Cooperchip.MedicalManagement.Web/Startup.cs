using Owin;
using System.Web.Services.Description;

namespace Cooperchip.MedicalManagement.Web
{
    /// <summary>
    /// Classe inicial do config da App
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// Método inicial do config da App
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {

            //public void ConfigureServices(IServiceCollection services)
            //{
            //    services.AddMvc();

            //    services.AddAuthorization(options =>
            //    {
            //        options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
            //    });
            //}

            ConfigureAuth(app);
        }

    }
}


