using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class StoreInRepository : AuditBaseRepository<StoreIn>, IStoreInRepository
    {
        protected override IQueryable<StoreIn> LoadQuery<TQ>(TQ query)
        {
            IQueryable<StoreIn> q = base.LoadQuery(query);
            var entityQuery = query as StoreInQuery;
            if (entityQuery == null) return q;

            if (entityQuery.SupplierId.HasValue)
            {
                q = q.Where(c => c.Supplier.Id == entityQuery.SupplierId);
            }
            
            if (entityQuery.SupplierName.NotNullAndEmpty())
            {
                q = q.Where(c => c.Supplier.Name.Contains(entityQuery.SupplierName));
            }

            if (entityQuery.BuyerId.HasValue)
            {
                q = q.Where(c => c.Buyer.Id == entityQuery.BuyerId);
            }

            if (entityQuery.BuyerName.NotNullAndEmpty())
            {
                q = q.Where(c => c.Buyer.LoginName.Contains(entityQuery.BuyerName));
            }

            if (entityQuery.StoreInTypeId.HasValue)
            {
                q = q.Where(c => c.StoreInType.Id == entityQuery.StoreInTypeId);
            }

            if (entityQuery.AmountPay != null)
            {
                if (entityQuery.AmountPay.Start.HasValue)
                {
                    q = q.Where(c => c.AmountPay >= entityQuery.AmountPay.Start);
                }

                if (entityQuery.AmountPay.End.HasValue)
                {
                    q = q.Where(c => c.AmountPay < entityQuery.AmountPay.End);
                }
            }

            return q;
        }
        
    }
}
