using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class StoreTransferDetailRepository : StoreGoodsRepository<StoreTransferDetail>, IStoreTransferDetailRepository
    {
        protected override IQueryable<StoreTransferDetail> LoadQuery<TQ>(TQ query)
        {
            IQueryable<StoreTransferDetail> q = base.LoadQuery(query);
            var entityQuery = query as StoreTransferDetailQuery;
            if (entityQuery == null) return q;

            if (entityQuery.GoodsTransferId.HasValue)
            {
                q = q.Where(c => c.GoodsTransfer.Id == entityQuery.GoodsTransferId);
            }
            return q;
        }
        
    }
}
