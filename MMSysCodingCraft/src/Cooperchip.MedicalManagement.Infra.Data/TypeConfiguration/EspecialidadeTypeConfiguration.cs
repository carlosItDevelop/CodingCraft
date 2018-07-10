using Cooperchip.Common.Entity.Config.TemplateMethod;
using Cooperchip.MedicalManagement.Domain.Entidade;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Infra.Data.TypeConfiguration
{
    class EspecialidadeTypeConfiguration : CooperchipEntityAbstractConfig<Especialidade>
    {
        protected override void FieldsFluentConfig()
        {
            Property(i => i.EspecialidadeId)
                .HasColumnName("EspecialidadeId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("Descricao");
        }

        protected override void ForeignKeyFluentConfig()
        {
            // Verificar se tem Fk;
        }

        protected override void PrimaryKeyFluentConfig()
        {
            HasKey(e => e.EspecialidadeId);
        }

        protected override void TableFluentConfig()
        {
            ToTable("Especialidade");
        }
    }
}
