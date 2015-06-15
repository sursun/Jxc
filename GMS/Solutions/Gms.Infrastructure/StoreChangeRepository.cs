using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class StoreChangeRepository : RepositoryBase<StoreChange>, IStoreChangeRepository
    {
        protected override IQueryable<StoreChange> LoadQuery<TQ>(TQ query)
        {

            IQueryable<StoreChange> q = base.LoadQuery(query);
            var storeChangeQuery = query as StoreChangeQuery;
            if (storeChangeQuery == null) return q;

            if (storeChangeQuery.GlassTypeId.HasValue)
            {
                q = q.Where(c => c.GlassStore.GlassType.Id == storeChangeQuery.GlassTypeId);
            }

            if (storeChangeQuery.Thickness.HasValue)
            {
                q = q.Where(c => c.GlassStore.Thickness == storeChangeQuery.Thickness);
            }

            if (storeChangeQuery.GlassUsage.HasValue)
            {
                q = q.Where(c => c.GlassUsage == storeChangeQuery.GlassUsage);
            }

            if (!storeChangeQuery.OrderCodeNo.IsNullOrEmpty())
            {
                q = q.Where(c => c.Order.CodeNo.Contains(storeChangeQuery.OrderCodeNo));
            }

            if (storeChangeQuery.CreateTime != null)
            {
                if (storeChangeQuery.CreateTime.Start.HasValue)
                {
                    q = q.Where(c => c.CreateTime >= storeChangeQuery.CreateTime.Start);
                }

                if (storeChangeQuery.CreateTime.End.HasValue)
                {
                    q = q.Where(c => c.CreateTime <= storeChangeQuery.CreateTime.End);
                }
            }

            return q;
        }
    }
}
