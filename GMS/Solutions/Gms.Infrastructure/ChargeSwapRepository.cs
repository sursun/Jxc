using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class ChargeSwapRepository : AuditBaseRepository<ChargeSwap>, IChargeSwapRepository
    {
        protected override IQueryable<ChargeSwap> LoadQuery<TQ>(TQ query)
        {
            IQueryable<ChargeSwap> q = base.LoadQuery(query);
            var entityQuery = query as ChargeSwapQuery;
            if (entityQuery == null) return q;

            if (entityQuery.OrigAccountId.HasValue)
            {
                q = q.Where(c => c.OrigAccount.Id == entityQuery.OrigAccountId);
            }

            if (entityQuery.DestAccountId.HasValue)
            {
                q = q.Where(c => c.DestAccount.Id == entityQuery.DestAccountId);
            }

            if (entityQuery.Amount != null)
            {
                if (entityQuery.Amount.Start.HasValue)
                {
                    q = q.Where(c => c.Amount >= entityQuery.Amount.Start);
                }

                if (entityQuery.Amount.End.HasValue)
                {
                    q = q.Where(c => c.Amount < entityQuery.Amount.End);
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
