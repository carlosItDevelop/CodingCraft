using Cooperchip.MedicalManagement.Domain.Entidade;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Linq;
using System.Web;
using System.Data.Entity.Validation;
using Cooperchip.MedicalManagement.Domain.Entidade.Interfaces;
using Cooperchip.MedicalManagement.Infra.Data.TypeConfiguration;

namespace Cooperchip.MedicalManagement.Infra.Data
{
    public partial class MedicalManagementDbContext : DbContext
    {
        public MedicalManagementDbContext()
            : base("DefaultConnection")
        {

        }

        public override int SaveChanges()
        {
            try
            {
                var currentTime = DateTime.Now;

                foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity != null &&
                        typeof(IEntidadeNaoEditavel).IsAssignableFrom(e.Entity.GetType())))
                {
                    if (entry.State == EntityState.Added)
                    {

                        if (entry.Property(nameof(IEntidadeNaoEditavel.DataInclusao)) != null)
                        {                  
                            entry.Property(nameof(IEntidadeNaoEditavel.DataInclusao)).CurrentValue = currentTime;
                        }                  
                        if (entry.Property(nameof(IEntidadeNaoEditavel.UsuarioInclusao)) != null)
                        {                  
                            entry.Property(nameof(IEntidadeNaoEditavel.UsuarioInclusao)).CurrentValue = HttpContext.Current != null ? HttpContext.Current.User.Identity.Name : "Usuario";
                        }
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property(nameof(IEntidade.DataInclusao)).IsModified = false;
                        entry.Property(nameof(IEntidade.UsuarioInclusao)).IsModified = false;

                        if (entry.Property(nameof(IEntidade.DataUltimaModificacao)) != null)
                        { 
                            entry.Property(nameof(IEntidade.DataUltimaModificacao)).CurrentValue = currentTime;
                        }                  
                        if (entry.Property(nameof(IEntidade.UsuarioUltimaModificacao)) != null)
                        {                  
                            entry.Property(nameof(IEntidade.UsuarioUltimaModificacao)).CurrentValue = HttpContext.Current != null ? HttpContext.Current.User.Identity.Name : "Usuario";
                        }
                    }
                }

                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);

                var exceptionsMessage = string.Concat(ex.Message, "Os erros de validações são: ", fullErrorMessage);

                throw new DbEntityValidationException(exceptionsMessage, ex.EntityValidationErrors);
            }
        }


        #region: DbSets

        // Provisório para migrar dados do Excel
        public DbSet<ApresentacaoAux> ApresentacaoAux { get; set; }

        public DbSet<ProntuarioBase> ProntuarioBase { get; set; }
        public DbSet<Invasoes> Invasoes { get; set; }
        public DbSet<NotificacoesProntuario> NotificacoesProntuario { get; set; }

        public DbSet<ExameParametros> ExameParametros { get; set; }

        public DbSet<ResultadoExame> ResultadoExame { get; set; }

        public DbSet<Acesso> Acesso { get; set; }


        public DbSet<AuxUniGeog> AuxUniGeog { get; set; }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<PessoaFisica> PessoaFisica { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridica { get; set; }


        public DbSet<ChamadaMedico> ChamadaMedico { get; set; }

        public DbSet<ApresentacaoAjusteInteracao> ApresentacaoAjusteInteracao { get; set; }


        public DbSet<TipoDePrecaucao> TipoDePrecaucao { get; set; }
        public DbSet<Precaucao> Precaucao { get; set; }

        public DbSet<ProntuarioPrecaucao> ProntuarioPrecaucao { get; set; }

        public DbSet<ContraIndicacao> ContraIndicacao { get; set; }

        public DbSet<TipoDreno> TipoDreno { get; set; }

        public DbSet<Dreno> Dreno { get; set; }

        public DbSet<Events> Events { get; set; }

        public DbSet<TelefonePaciente> TelefonePaciente { get; set; }

        public DbSet<UnidadeGeografica> UnidadeGeografica { get; set; }

        public DbSet<Setor> Setor { get; set; }

        public DbSet<Generico> Generico { get; set; }

        public DbSet<Endereco> Endereco { get; set; }

        public DbSet<BaseDeConhecimento> BaseDeConhecimento { get; set; }
        public DbSet<Uf> Uf { get; set; }
        public DbSet<TipoTelefone> TipoTelefone { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Bairro> Bairro { get; set; }
        public DbSet<Convenio> Convenio { get; set; }
        public DbSet<Leito> Leito { get; set; }
        public DbSet<AtbJaUtilizado> AtbJaUtilizado { get; set; }
        public DbSet<Anticoagulacao> Anticoagulacao { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Alergia> Alergia { get; set; }
        public DbSet<Fisioterapia>  Fisioterapia { get; set; }
        public DbSet<HistoriaPatologicaPregressa> HistoriaPatologicaPregressa { get; set; }
        public DbSet<Complicacao>  Complicacao { get; set; }
        public DbSet<Prontuario> Prontuario { get; set; }
        public DbSet<TabelasBase> TabelasBase { get; set; }
        public DbSet<Mural> Mural { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<EstadoDoPaciente> EstadoDoPaciente { get; set; }
        public DbSet<CidAdaptada> CidAdaptada { get; set; }
        public DbSet<AtbEmUso> AtbEmUso { get; set; }
        public DbSet<ExameDeImagem> ExameDeImagem { get; set; }
        public DbSet<BalancoHidrico> BalancoHidrico { get; set; }
        public DbSet<ExameDescricao> ExameDescricao { get; set; }

        public DbSet<SinaisVitais> SinaisVitais { get; set; }

        public DbSet<Agendamento> Agendamento { get; set; }


        // --------------------------------------------------------------- //
        public DbSet<Prescricao> Prescricao { get; set; }
        public DbSet<Dieta> Dieta { get; set; }
        // --------------------------------------------------------------- //

        public DbSet<Contato> Contato { get; set; }
        public DbSet<Operadora> Operadora { get; set; }

        // --------------------------------------------------------------- //

        public DbSet<Medicamento> Medicamento { get; set; }
        public DbSet<MedicamentoPosologia> MedicamentoPosologia { get; set; }
        public DbSet<MedicamentoApresentacao> MedicamentoApresentacao { get; set; }
        public DbSet<MedicamentoAjustes> MedicamentoAjustes { get; set; }

        // --------------------------------------------------------------- //
        public DbSet<InteracaoMedicamentosa> InteracaoMedicamentosa { get; set; }
        // --------------------------------------------------------------- //
        public DbSet<Classe> Classe { get; set; }
        // --------------------------------------------------------------- //
        public DbSet<Parametro> Parametro { get; set; }

        // --------------------------------------------------------------- //

        #endregion: DbSet

        #region: OnModelCreating

        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new EspecialidadeTypeConfiguration());

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(80));

            // Configurações de Medico

        }

        #endregion

    }
}
