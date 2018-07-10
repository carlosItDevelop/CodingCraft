using System.Data.Entity.ModelConfiguration;

namespace Cooperchip.Common.Entity.Config.TemplateMethod
{
    public abstract class CooperchipEntityAbstractConfig<TEntity> : EntityTypeConfiguration<TEntity> 
        where TEntity : class
    {
        public CooperchipEntityAbstractConfig()
        {
            TableFluentConfig();
            FieldsFluentConfig();
            PrimaryKeyFluentConfig();
            ForeignKeyFluentConfig();
        }

        protected abstract void ForeignKeyFluentConfig();
        protected abstract void PrimaryKeyFluentConfig();
        protected abstract void FieldsFluentConfig();
        protected abstract void TableFluentConfig();
    }
}
