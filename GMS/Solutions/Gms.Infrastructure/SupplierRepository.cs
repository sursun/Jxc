using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class SupplierRepository : RelationPersonRepository<Supplier>, ISupplierRepository
    {
        protected override IQueryable<Supplier> LoadQuery<TQ>(TQ query)
        {
            IQueryable<Supplier> q = base.LoadQuery(query);
            var entityQuery = query as SupplierQuery;
            if (entityQuery == null) return q;

            if (entityQuery.SupplierTypeId.HasValue)
            {
                q = q.Where(c => c.SupplierType.Id==entityQuery.SupplierTypeId);
            }

            if (!entityQuery.ShuiHao.IsNullOrEmpty())
            {
                q = q.Where(c => c.ShuiHao.Contains(entityQuery.ShuiHao));
            }

            if (!entityQuery.CardNo.IsNullOrEmpty())
            {
                q = q.Where(c => c.CardNo.Contains(entityQuery.CardNo));
            }

            if (entityQuery.TaxRate != null)
            {
                if (entityQuery.TaxRate.Start.HasValue)
                {
                    q = q.Where(c => c.TaxRate >= entityQuery.TaxRate.Start);
                }

                if (entityQuery.TaxRate.End.HasValue)
                {
                    q = q.Where(c => c.TaxRate < entityQuery.TaxRate.End);
                }
            }

            if (entityQuery.FukuanQc != null)
            {
                if (entityQuery.FukuanQc.Start.HasValue)
                {
                    q = q.Where(c => c.FukuanQc >= entityQuery.FukuanQc.Start);
                }

                if (entityQuery.FukuanQc.End.HasValue)
                {
                    q = q.Where(c => c.FukuanQc < entityQuery.FukuanQc.End);
                }
            }

            if (entityQuery.FukuanYing != null)
            {
                if (entityQuery.FukuanYing.Start.HasValue)
                {
                    q = q.Where(c => c.FukuanYing >= entityQuery.FukuanYing.Start);
                }

                if (entityQuery.FukuanYing.End.HasValue)
                {
                    q = q.Where(c => c.FukuanYing < entityQuery.FukuanYing.End);
                }
            }
            
            if (entityQuery.FukuanYu != null)
            {
                if (entityQuery.FukuanYu.Start.HasValue)
                {
                    q = q.Where(c => c.FukuanYu >= entityQuery.FukuanYu.Start);
                }

                if (entityQuery.FukuanYu.End.HasValue)
                {
                    q = q.Where(c => c.FukuanYu < entityQuery.FukuanYu.End);
                }
            }
            
            return q;
        }
    }
}
