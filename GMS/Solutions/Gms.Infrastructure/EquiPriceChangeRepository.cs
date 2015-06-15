using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class EquiPriceChangeRepository : RepositoryBase<EquiPriceChange>, IEquiPriceChangeRepository
    {
        protected override IQueryable<EquiPriceChange> LoadQuery<TQ>(TQ query)
        {
            IQueryable<EquiPriceChange> q = base.LoadQuery(query);
            var entityQuery = query as EquiPriceChangeQuery;
            if (entityQuery == null) return q;

            if (entityQuery.EquiName.NotNullAndEmpty())
            {
                q = q.Where(c => c.EquiIn.Equipment.Name.Contains(entityQuery.EquiName));
            }

            if (entityQuery.CreateDateTime != null)
            {
                if (entityQuery.CreateDateTime.Start.HasValue)
                {
                    q = q.Where(c => c.CreateDateTime >= entityQuery.CreateDateTime.Start);
                }

                if (entityQuery.CreateDateTime.End.HasValue)
                {
                    q = q.Where(c => c.CreateDateTime < entityQuery.CreateDateTime.End);
                }
            }

            return q;
        }
    }
}
