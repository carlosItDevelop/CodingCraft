using Cooperchip.MedicalManagement.Infra.Data;

namespace Cooperchip.MedicalManagement.Infra.Data.Migrations
{
    using Cooperchip.MedicalManagement.Domain.Entidade;
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MedicalManagementDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["MigracoesAutomaticas"].ToString());
            AutomaticMigrationDataLossAllowed = Convert.ToBoolean(ConfigurationManager.AppSettings["MigracoesAutomaticas"].ToString());
        }

        protected override void Seed(MedicalManagementDbContext context)
        {
            // Pessoas Físicas
            context.PessoaFisica.AddOrUpdate(pf => pf.CpfOrCnpj, 
                new PessoaFisica { NomeOuRazaoSocial = "Carlos Alberto dos Santos", CpfOrCnpj = "75535785768", Ativo = true, DataEmissaoRg = new DateTime(1998, 12, 20),
                    DataNascimentoOuFundacao = new DateTime(1977, 11, 2), Email = "carlos.poetarj@gmail.com", EstadoCivil = Domain.Enum.EstadoCivil.Divorciado, OrgaoEmissorRg = "IFP", PessoaId = Guid.NewGuid(),
                    Sexo = Domain.Enum.Sexo.Masculino, Rg = "07152955-6" },
                new PessoaFisica
                {
                    NomeOuRazaoSocial = "Claudio Henrique da Silva",
                    CpfOrCnpj = "70514325089",
                    Ativo = true,
                    DataEmissaoRg = new DateTime(1992, 5, 25),
                    DataNascimentoOuFundacao = new DateTime(1975, 9, 21),
                    Email = "claudio.h.silva@cooperchip.com.br",
                    EstadoCivil = Domain.Enum.EstadoCivil.Casado,
                    OrgaoEmissorRg = "IFP",
                    PessoaId = Guid.NewGuid(),
                    Sexo = Domain.Enum.Sexo.Masculino,
                    Rg = "07455758-6"
                });


            context.SaveChanges();

            // Especialidades
            context.Especialidade.AddOrUpdate(e => e.Descricao, 
                new Especialidade { Descricao = "Cardiologia" },
                new Especialidade { Descricao = "Geriatria" },
                new Especialidade { Descricao = "Neurologia" },
                new Especialidade { Descricao = "Nefrologia" },
                new Especialidade { Descricao = "Pediatria" }
            );
            context.SaveChanges();

            // Médicos

            var medico = context.PessoaFisica.FirstOrDefault(pf => pf.CpfOrCnpj == "70514325089");
            var especialidade = context.Especialidade.OrderBy(_ => Guid.NewGuid()).FirstOrDefault();

            context.Medico.AddOrUpdate(m => m.MedicoId,
                new Medico { MedicoId = medico.PessoaId, Crm = "73849506", EspecialidadeId = especialidade.EspecialidadeId });
        }
    }
}