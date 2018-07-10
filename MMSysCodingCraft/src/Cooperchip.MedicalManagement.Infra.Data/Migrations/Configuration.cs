using Cooperchip.MedicalManagement.Infra.Data;

namespace Cooperchip.MedicalManagement.Infra.Data.Migrations
{
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MedicalManagementDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["MigracoesAutomaticas"].ToString());
            AutomaticMigrationDataLossAllowed = Convert.ToBoolean(ConfigurationManager.AppSettings["MigracoesAutomaticas"].ToString());
        }

        protected override void Seed(MedicalManagementDbContext context)
        {

           
        }
    }
}