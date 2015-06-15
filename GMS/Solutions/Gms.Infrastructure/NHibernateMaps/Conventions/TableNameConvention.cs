namespace Gms.Infrastructure.NHibernateMaps.Conventions
{
    #region Using Directives

    using FluentNHibernate.Conventions;

    using inflector_extension;
    #endregion

    public class TableNameConvention : IClassConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IClassInstance instance)
        {
            string name = instance.EntityType.FullName.Replace("Gms.Domain.", "").Replace(".", "_");
            instance.Table(name.InflectTo().Pluralized);
            //instance.Table(instance.EntityType.Name.InflectTo().Pluralized);
        }
    }
}