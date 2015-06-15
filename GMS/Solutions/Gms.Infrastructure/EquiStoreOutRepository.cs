using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class EquiStoreOutRepository : RepositoryBase<EquiStoreOut>, IEquiStoreOutRepository
    {
        protected override IQueryable<EquiStoreOut> LoadQuery<TQ>(TQ query)
        {
            IQueryable<EquiStoreOut> q = base.LoadQuery(query);
            var entityQuery = query as EquiStoreOutQuery;
            if (entityQuery == null) return q;

            if (entityQuery.CodeNo.NotNullAndEmpty())
            {
                q = q.Where(c => c.CodeNo.Contains(entityQuery.CodeNo));
            }

            if (entityQuery.EquiToId.HasValue)
            {
                q = q.Where(c => c.EquiTo.Id == entityQuery.EquiToId);
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

            if (entityQuery.UserName.NotNullAndEmpty())
            {
                q = q.Where(c => c.User.LoginName.Contains(entityQuery.UserName));
            }

            if (entityQuery.CreateDateTime != null)
            {
                if (entityQuery.CreateDateTime.Start.HasValue)
                {
                    q = q.Where(c => c.CreateDateTime >= entityQuery.CreateDateTime.Start);
                }

                if (entityQuery.CreateDateTime.End.HasValue)
                {
                    q = q.Where(c => c.CreateDateTime < entityQuery.CreateDateTime.End);
                }
            }

            if (entityQuery.Note.NotNullAndEmpty())
            {
                q = q.Where(c => c.Note.Contains(entityQuery.Note));
            }
            
            return q;
        }
    }
}
