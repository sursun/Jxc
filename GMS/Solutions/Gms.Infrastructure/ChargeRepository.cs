using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class ChargeRepository : AuditBaseRepository<Charge>, IChargeRepository
    {
        protected override IQueryable<Charge> LoadQuery<TQ>(TQ query)
        {
            IQueryable<Charge> q = base.LoadQuery(query);
            var entityQuery = query as ChargeQuery;
            if (entityQuery == null) return q;

            if (entityQuery.AccountId.HasValue)
            {
                q = q.Where(c => c.Account.Id == entityQuery.AccountId);
            }

            if (entityQuery.ChargeTypeFlag.HasValue)
            {
                q = q.Where(c => c.ChargeType.Type == entityQuery.ChargeTypeFlag);
            }

            if (entityQuery.ChargeTypeId.HasValue)
            {
                q = q.Where(c => c.ChargeType.Id == entityQuery.ChargeTypeId);
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

            if (entityQuery.UserId.HasValue)
            {
                q = q.Where(c => c.User.Id == entityQuery.UserId);
            }

            if (!entityQuery.UserName.IsNullOrEmpty())
            {
                q = q.Where(c => c.User.LoginName.Contains(entityQuery.UserName));
            }

            if (entityQuery.AutoCreate.HasValue)
            {
                q = q.Where(c => c.AutoCreate == entityQuery.AutoCreate);
            }
            
            if (!entityQuery.Note.IsNullOrEmpty())
            {
                q = q.Where(c => c.Note.Contains(entityQuery.Note));
            }
            
            return q;
        }
    }
}
