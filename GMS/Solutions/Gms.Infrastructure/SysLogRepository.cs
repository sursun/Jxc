using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class SysLogRepository : RepositoryBase<SysLog>, ISysLogRepository
    {
        protected override IQueryable<SysLog> LoadQuery<TQ>(TQ query)
        {
            IQueryable<SysLog> q = base.LoadQuery(query);
            var entityQuery = query as SysLogQuery;
            if (entityQuery == null) return q;

            if (entityQuery.UserId.HasValue)
            {
                q = q.Where(c => c.User.Id == entityQuery.UserId);
            }

            if (!entityQuery.UserName.IsNullOrEmpty())
            {
                q = q.Where(c => c.User.LoginName.Contains(entityQuery.UserName));
            }
            
            if (!entityQuery.Content.IsNullOrEmpty())
            {
                q = q.Where(c => c.Content.Contains(entityQuery.Content));
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

            

            return q;
        }
    }
}
