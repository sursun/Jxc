using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping.Alterations;
using Gms.Domain;

namespace Gms.Infrastructure.NHibernateMaps
{
    public class CureProcessMap : IAutoMappingOverride<CureProcess>
    {
        public void Override(FluentNHibernate.Automapping.AutoMapping<CureProcess> mapping)
        {
            mapping.HasManyToMany(c => c.CureTypes).Table("CureProcess_CureTypes");
        }
    }
}
