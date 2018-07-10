using Cooperchip.Common.Entity.Config.TemplateMethod;
using Cooperchip.MedicalManagement.Domain.Entidade;

namespace Cooperchip.MedicalManagement.Infra.Data.TypeConfiguration
{
    class MedicoTypeConfiguration : CooperchipEntityAbstractConfig<Medico>
    {
        protected override void FieldsFluentConfig()
        {
            Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("Nome");

            Property(c => c.Crm)
                .HasColumnName("Crm")
                .HasMaxLength(10);

            Property(dt => dt.DataNascimento)
                .HasColumnName("DataNascimento");
                //.HasColumnType("datetime2");
        }

        protected override void ForeignKeyFluentConfig()
        {
            
        }

        protected override void PrimaryKeyFluentConfig()
        {
            HasKey(e => e.MedicoId);
        }

        protected override void TableFluentConfig()
        {
            ToTable("Medico");
        }
    }
}


/*
 

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [ForeignKey("Especialidade")]
        [Display(Name = "Especialidade")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public int IdEspecialidade { get; set; }

        public virtual Especialidade Especialidade { get; set; }
     
 */
