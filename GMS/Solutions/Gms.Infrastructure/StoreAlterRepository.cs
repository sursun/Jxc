using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class StoreAlterRepository : AuditBaseRepository<StoreAlter>, IStoreAlterRepository
    {
        protected override IQueryable<StoreAlter> LoadQuery<TQ>(TQ query)
        {
            IQueryable<StoreAlter> q = base.LoadQuery(query);
            var entityQuery = query as StoreAlterQuery;
            if (entityQuery == null) return q;

            if (!entityQuery.CodeNo.IsNullOrEmpty())
            {
                q = q.Where(c => c.CodeNo.Contains(entityQuery.CodeNo));
            }

            if (!entityQuery.OrderCode.IsNullOrEmpty())
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

            if (entityQuery.AccountId.HasValue)
            {
                q = q.Where(c => c.Account.Id == entityQuery.AccountId);
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

            if (entityQuery.Debt != null)
            {
                if (entityQuery.Debt.Start.HasValue)
                {
                    q = q.Where(c => c.Debt >= entityQuery.Debt.Start);
                }

                if (entityQuery.Debt.End.HasValue)
                {
                    q = q.Where(c => c.Debt < entityQuery.Debt.End);
                }
            }

            if (!entityQuery.Payer.IsNullOrEmpty())
            {
                q = q.Where(c => c.Payer.Contains(entityQuery.Payer));
            }

            if (!entityQuery.Payee.IsNullOrEmpty())
            {
                q = q.Where(c => c.Payee.Contains(entityQuery.Payee));
            }
            
            if (!entityQuery.Note.IsNullOrEmpty())
            {
                q = q.Where(c => c.Note.Contains(entityQuery.Note));
            }
            
            return q;
        }
    }
}
