using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class GlassStoreRepository : RepositoryBase<GlassStore>, IGlassStoreRepository
    {
        protected override IQueryable<GlassStore> LoadQuery<TQ>(TQ query)
        {

            IQueryable<GlassStore> q = base.LoadQuery(query);
            var glassStoreQuery = query as GlassStoreQuery;
            if (glassStoreQuery == null) return q;
            
            if (glassStoreQuery.GlassTypeId.HasValue)
            {
                q = q.Where(c => c.GlassType.Id == glassStoreQuery.GlassTypeId);
            }

            if (glassStoreQuery.Thickness.HasValue)
            {
                q = q.Where(c => c.Thickness == glassStoreQuery.Thickness);
            }

            if (glassStoreQuery.LongEdge.HasValue)
            {
                q = q.Where(c => c.LongEdge == glassStoreQuery.LongEdge);
            }

            if (glassStoreQuery.ShortEdge.HasValue)
            {
                q = q.Where(c => c.ShortEdge == glassStoreQuery.ShortEdge);
            }

            if (glassStoreQuery.Amount != null)
            {
                if (glassStoreQuery.Amount.Start.HasValue)
                {
                    q = q.Where(c => c.Amount >= glassStoreQuery.Amount.Start);
                }

                if (glassStoreQuery.Amount.End.HasValue)
                {
                    q = q.Where(c => c.Amount <= glassStoreQuery.Amount.End);
                }
            }

            return q;
        }
    }
}
