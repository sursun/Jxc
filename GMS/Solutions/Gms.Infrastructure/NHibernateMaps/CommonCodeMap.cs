using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping.Alterations;
using Gms.Domain;

namespace Gms.Infrastructure.NHibernateMaps
{
    public class CommonCodeMap : IAutoMappingOverride<CommonCode>
    {
        public void Override(FluentNHibernate.Automapping.AutoMapping<CommonCode> mapping)
        {

            mapping.Map(c => c.Type).CustomType<CommonCodeType>();

            mapping.HasMany(c => c.Subs).KeyColumn("ParentFk").ForeignKeyConstraintName("fk_CommonCode_ParentCommonCode").LazyLoad().Cascade.All();

        }
    }
}
