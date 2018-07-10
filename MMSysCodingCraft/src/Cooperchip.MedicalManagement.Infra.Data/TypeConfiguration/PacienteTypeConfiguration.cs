using Cooperchip.Common.Entity.Config.TemplateMethod;
using Cooperchip.MedicalManagement.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperchip.MedicalManagement.Infra.Data.TypeConfiguration
{
    class PacienteTypeConfiguration : CooperchipEntityAbstractConfig<Paciente>
    {
        protected override void FieldsFluentConfig()
        {
            Property(x => x.Alergia)
                .HasMaxLength(120);
            Property(x => x.CodigoCid)
                .IsRequired()
                .HasMaxLength(5);
            Property(x => x.Complicacao)
                .IsRequired()
                .HasMaxLength(150);
        }

        protected override void ForeignKeyFluentConfig()
        {
            
        }

        protected override void PrimaryKeyFluentConfig()
        {
            HasKey(x => x.PacienteId);
        }

        protected override void TableFluentConfig()
        {
            ToTable("Paciente");
        }
    }
}
