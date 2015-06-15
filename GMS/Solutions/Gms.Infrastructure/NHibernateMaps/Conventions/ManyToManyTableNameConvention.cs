using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions.Inspections;

namespace Gms.Infrastructure.NHibernateMaps.Conventions
{
    public class ManyToManyTableNameConvention : FluentNHibernate.Conventions.ManyToManyTableNameConvention
    {
        protected override string GetBiDirectionalTableName(IManyToManyCollectionInspector collection,
            IManyToManyCollectionInspector otherSide)
        {

            return (collection.EntityType.Name.InflectTo().Pluralized) + "_" +
                (otherSide.EntityType.Name.InflectTo().Pluralized);
        }

        protected override string GetUniDirectionalTableName(IManyToManyCollectionInspector collection)
        {
            return (collection.EntityType.Name.InflectTo().Pluralized) + "_" +
                (collection.ChildType.Name.InflectTo().Pluralized);
        }
    }
}
