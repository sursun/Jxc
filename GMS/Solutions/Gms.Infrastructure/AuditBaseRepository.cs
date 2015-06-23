using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class AuditBaseRepository<T> : RepositoryBase<T>, IAuditBaseRepository<T> where T : Gms.Domain.AuditBase
    {
        protected override IQueryable<T> LoadQuery<TQ>(TQ query)
        {
            IQueryable<T> q = base.LoadQuery(query);
            var entityQuery = query as AuditBaseQuery;
            if (entityQuery == null) return q;

            if (entityQuery.CreatorId.HasValue)
            {
                q = q.Where(c=>c.Creator.Id == entityQuery.CreatorId);
            }

            if (!entityQuery.CreatorName.IsNullOrEmpty())
            {
                q = q.Where(c => c.Creator.LoginName.Contains(entityQuery.CreatorName));
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

            if (entityQuery.AuditorId.HasValue)
            {
                q = q.Where(c => c.Auditor.Id == entityQuery.AuditorId);
            }

            if (!entityQuery.AuditorName.IsNullOrEmpty())
            {
                q = q.Where(c => c.Auditor.LoginName.Contains(entityQuery.AuditorName));
            }

            if (entityQuery.AuditTime != null)
            {
                if (entityQuery.AuditTime.Start.HasValue)
                {
                    q = q.Where(c => c.AuditTime >= entityQuery.AuditTime.Start);
                }

                if (entityQuery.AuditTime.End.HasValue)
                {
                    q = q.Where(c => c.AuditTime < entityQuery.AuditTime.End);
                }
            }

            if (entityQuery.CreatorId.HasValue)
            {
                q = q.Where(c => c.Creator.Id == entityQuery.CreatorId);
            }

            if (!entityQuery.AuditNote.IsNullOrEmpty())
            {
                q = q.Where(c => c.AuditNote.Contains(entityQuery.AuditNote));
            }
            
            return q;
        }
    }
}
