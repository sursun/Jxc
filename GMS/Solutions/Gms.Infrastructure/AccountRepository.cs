using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        protected override IQueryable<Account> LoadQuery<TQ>(TQ query)
        {
            IQueryable<Account> q = base.LoadQuery(query);
            var entityQuery = query as AccountQuery;
            if (entityQuery == null) return q;
            
            if (!entityQuery.CodeNo.IsNullOrEmpty())
            {
                q = q.Where(c => c.CodeNo.Contains(entityQuery.CodeNo));
            }

            if (!entityQuery.Name.IsNullOrEmpty())
            {
                q = q.Where(c => c.Name.Contains(entityQuery.Name));
            }

            if (entityQuery.CurAmount != null)
            {
                if (entityQuery.CurAmount.Start.HasValue)
                {
                    q = q.Where(c => c.CurAmount >= entityQuery.CurAmount.Start);
                }

                if (entityQuery.CurAmount.End.HasValue)
                {
                    q = q.Where(c => c.CurAmount < entityQuery.CurAmount.End);
                }
            }

            if (entityQuery.BaseAmount != null)
            {
                if (entityQuery.BaseAmount.Start.HasValue)
                {
                    q = q.Where(c => c.BaseAmount >= entityQuery.BaseAmount.Start);
                }

                if (entityQuery.BaseAmount.End.HasValue)
                {
                    q = q.Where(c => c.BaseAmount < entityQuery.BaseAmount.End);
                }
            }

            if (entityQuery.CreateTime != null)
            {
                if (entityQuery.CreateTime.Start.HasValue)
                {
                    q = q.Where(c => c.CreateTime >= entityQuery.CreateTime.Start);
                }

                if (entityQuery.CreateTime.End.HasValue)
                {
                    q = q.Where(c => c.CreateTime < entityQuery.CreateTime.End);
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
