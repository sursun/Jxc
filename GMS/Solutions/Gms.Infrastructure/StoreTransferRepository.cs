using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class StoreTransferRepository : AuditBaseRepository<StoreTransfer>, IStoreTransferRepository
    {
        protected override IQueryable<StoreTransfer> LoadQuery<TQ>(TQ query)
        {
            IQueryable<StoreTransfer> q = base.LoadQuery(query);
            var entityQuery = query as StoreTransferQuery;
            if (entityQuery == null) return q;

            if (entityQuery.CodeNo.NotNullAndEmpty())
            {
                q = q.Where(c => c.CodeNo.Contains(entityQuery.CodeNo));
            }

            if (entityQuery.OrderCode.NotNullAndEmpty())
            {
                q = q.Where(c => c.OrderCode.Contains(entityQuery.OrderCode));
            }

            if (entityQuery.OrderTime != null)
            {
                if (entityQuery.OrderTime.Start.HasValue)
                {
                    q = q.Where(c => c.OrderTime >= entityQuery.OrderTime.Start);
                }

                if (entityQuery.OrderTime.End.HasValue)
                {
                    q = q.Where(c => c.OrderTime < entityQuery.OrderTime.End);
                }
            }

            if (entityQuery.FromStoreId.HasValue)
            {
                q = q.Where(c => c.FromStore.Id == entityQuery.FromStoreId);
            }

            if (entityQuery.ToStoreId.HasValue)
            {
                q = q.Where(c => c.ToStore.Id == entityQuery.ToStoreId);
            }

            if (entityQuery.Note.NotNullAndEmpty())
            {
                q = q.Where(c => c.Note.Contains(entityQuery.Note));
            }

            return q;
        }
        
    }
}
