using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class StoreGoodsRepository<T> : RepositoryBase<T>, IStoreGoodsRepository<T> where T : Gms.Domain.StoreGoods
    {
         protected override IQueryable<T> LoadQuery<TQ>(TQ query)
        {
            IQueryable<T> q = base.LoadQuery(query);
            var entityQuery = query as StoreGoodsQuery;
            if (entityQuery == null) return q;

            if (entityQuery.GoodsId.HasValue)
            {
                q = q.Where(c => c.Goods.Id == entityQuery.GoodsId);
            }

            if (entityQuery.Quantity != null)
            {
                if (entityQuery.Quantity.Start.HasValue)
                {
                    q = q.Where(c => c.Quantity >= entityQuery.Quantity.Start);
                }

                if (entityQuery.Quantity.End.HasValue)
                {
                    q = q.Where(c => c.Quantity < entityQuery.Quantity.End);
                }
            }

            if (entityQuery.Price != null)
            {
                if (entityQuery.Price.Start.HasValue)
                {
                    q = q.Where(c => c.Price >= entityQuery.Price.Start);
                }

                if (entityQuery.Price.End.HasValue)
                {
                    q = q.Where(c => c.Price < entityQuery.Price.End);
                }
            }

            if (entityQuery.TotalAomount != null)
            {
                if (entityQuery.TotalAomount.Start.HasValue)
                {
                    q = q.Where(c => c.TotalAomount >= entityQuery.TotalAomount.Start);
                }

                if (entityQuery.TotalAomount.End.HasValue)
                {
                    q = q.Where(c => c.TotalAomount < entityQuery.TotalAomount.End);
                }
            }
            
            if (!entityQuery.Note.IsNullOrEmpty())
            {
                q = q.Where(c => c.Note.Contains(entityQuery.Note));
            }

            return q;
        }
    }
}
