using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class GoodsPriceAlterRepository : AuditBaseRepository<GoodsPriceAlter>, IGoodsPriceAlterRepository
    {
       protected override IQueryable<GoodsPriceAlter> LoadQuery<TQ>(TQ query)
        {
            IQueryable<GoodsPriceAlter> q = base.LoadQuery(query);
            var entityQuery = query as GoodsPriceAlterQuery;
            if (entityQuery == null) return q;

            if (entityQuery.GoodsId.HasValue)
            {
                q = q.Where(c => c.Goods.Id == entityQuery.GoodsId);
            }
            
            if (entityQuery.Balance != null)
            {
                if (entityQuery.Balance.Start.HasValue)
                {
                    q = q.Where(c => c.Balance >= entityQuery.Balance.Start);
                }

                if (entityQuery.Balance.End.HasValue)
                {
                    q = q.Where(c => c.Balance < entityQuery.Balance.End);
                }
            }

            if (entityQuery.BalanceRatio != null)
            {
                if (entityQuery.BalanceRatio.Start.HasValue)
                {
                    q = q.Where(c => c.BalanceRatio >= entityQuery.BalanceRatio.Start);
                }

                if (entityQuery.BalanceRatio.End.HasValue)
                {
                    q = q.Where(c => c.BalanceRatio < entityQuery.BalanceRatio.End);
                }
            }

            if (entityQuery.StartTime != null)
            {
                if (entityQuery.StartTime.Start.HasValue)
                {
                    q = q.Where(c => c.StartTime >= entityQuery.StartTime.Start);
                }

                if (entityQuery.StartTime.End.HasValue)
                {
                    q = q.Where(c => c.StartTime < entityQuery.StartTime.End);
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
