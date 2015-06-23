using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class StoreInDetailRepository : StoreGoodsRepository<StoreInDetail>, IStoreInDetailRepository
    {
        protected override IQueryable<StoreInDetail> LoadQuery<TQ>(TQ query)
        {
            IQueryable<StoreInDetail> q = base.LoadQuery(query);
            var entityQuery = query as StoreInDetailQuery;
            if (entityQuery == null) return q;

            if (entityQuery.StoreInId.HasValue)
            {
                q = q.Where(c => c.StoreIn.Id == entityQuery.StoreInId);
            }
            return q;
        }
        
    }
}
