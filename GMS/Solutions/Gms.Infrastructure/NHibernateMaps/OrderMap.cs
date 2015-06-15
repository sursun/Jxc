using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping.Alterations;
using Gms.Domain;

namespace Gms.Infrastructure.NHibernateMaps
{
    public class OrderMap : IAutoMappingOverride<Order>
    {
        public void Override(FluentNHibernate.Automapping.AutoMapping<Order> mapping)
        {
            mapping.HasMany(c=>c.Cures);
            mapping.HasMany(c => c.Products);
        }
    }
}
