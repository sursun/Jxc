using System.IO;

namespace Gms.Infrastructure.NHibernateMaps
{
    #region Using Directives

    using System;

    using Conventions;

    using Domain;

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Conventions;

    using SharpArch.Domain.DomainModel;
    using SharpArch.NHibernate.FluentNHibernate;

    #endregion

    /// <summary>
    /// Generates the automapping for the domain assembly
    /// </summary>
    public class AutoPersistenceModelGenerator : IAutoPersistenceModelGenerator
    {
        public AutoPersistenceModel Generate()
        {
            var mappings = AutoMap.AssemblyOf<User>(new AutomappingConfiguration());
            mappings.IgnoreBase<Entity>();       
            mappings.IgnoreBase(typeof(EntityWithTypedId<>));
            mappings.Conventions.Setup(GetConventions());
            mappings.UseOverridesFromAssemblyOf<AutoPersistenceModelGenerator>();

#if DEBUG
            string mapPath = "d:\\map";
            if (!Directory.Exists(mapPath))
            {
                Directory.CreateDirectory(mapPath);
            }

            mappings.WriteMappingsTo(mapPath);
#endif
            return mappings;
        }

        private static Action<IConventionFinder> GetConventions()
        {
            return c =>
                   {
                       c.Add<PrimaryKeyConvention>();
                       c.Add<CustomForeignKeyConvention>();
                       c.Add<HasManyConvention>();
                       c.Add<TableNameConvention>();
                       c.Add<HasManyToManyConvention>();
                       c.Add<Gms.Infrastructure.NHibernateMaps.Conventions.ManyToManyTableNameConvention>();
                       c.Add<Gms.Infrastructure.NHibernateMaps.Conventions.PropertyConvention>();
                       c.Add<Gms.Infrastructure.NHibernateMaps.Conventions.ReferenceConvention>();

                   };
        }
    }
}