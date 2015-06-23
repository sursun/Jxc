using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class StoreOutRepository : AuditBaseRepository<StoreOut>, IStoreOutRepository
    {
        protected override IQueryable<StoreOut> LoadQuery<TQ>(TQ query)
        {
            IQueryable<StoreOut> q = base.LoadQuery(query);
            var entityQuery = query as StoreOutQuery;
            if (entityQuery == null) return q;

            if (entityQuery.CustomerId.HasValue)
            {
                q = q.Where(c => c.Customer.Id == entityQuery.CustomerId);
            }

            if (entityQuery.CustomerName.NotNullAndEmpty())
            {
                q = q.Where(c => c.Customer.Name.Contains(entityQuery.CustomerName));
            }

            if (entityQuery.SellerId.HasValue)
            {
                q = q.Where(c => c.Seller.Id == entityQuery.SellerId);
            }

            if (entityQuery.SellerName.NotNullAndEmpty())
            {
                q = q.Where(c => c.Seller.LoginName.Contains(entityQuery.SellerName));
            }

            if (entityQuery.StoreOutTypeId.HasValue)
            {
                q = q.Where(c => c.StoreOutType.Id == entityQuery.StoreOutTypeId);
            }

            if (entityQuery.AmountReceipt != null)
            {
                if (entityQuery.AmountReceipt.Start.HasValue)
                {
                    q = q.Where(c => c.AmountReceipt >= entityQuery.AmountReceipt.Start);
                }

                if (entityQuery.AmountReceipt.End.HasValue)
                {
                    q = q.Where(c => c.AmountReceipt < entityQuery.AmountReceipt.End);
                }
            }

            return q;
        }
        
    }
}
