using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class StoreOutDetailRepository : StoreGoodsRepository<StoreOutDetail>, IStoreOutDetailRepository
    {
        protected override IQueryable<StoreOutDetail> LoadQuery<TQ>(TQ query)
        {
            IQueryable<StoreOutDetail> q = base.LoadQuery(query);
            var entityQuery = query as StoreOutDetailQuery;
            if (entityQuery == null) return q;

            if (entityQuery.StoreOutId.HasValue)
            {
                q = q.Where(c => c.StoreOut.Id == entityQuery.StoreOutId);
            }
            return q;
        }
        
    }
}
