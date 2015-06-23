using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class RelationPersonRepository<T> : RepositoryBase<T>, IRelationPersonRepository<T> where T : Gms.Domain.RelationPerson
    {
        protected override IQueryable<T> LoadQuery<TQ>(TQ query)
        {
            IQueryable<T> q = base.LoadQuery(query);
            var entityQuery = query as RelationPersonQuery;
            if (entityQuery == null) return q;

            if (entityQuery.RelationType.HasValue)
            {
                q = q.Where(c => c.RelationType == entityQuery.RelationType);
            }

            if (!entityQuery.CodeNo.IsNullOrEmpty())
            {
                q = q.Where(c => c.CodeNo.Contains(entityQuery.CodeNo));
            }

            if (!entityQuery.Name.IsNullOrEmpty())
            {
                q = q.Where(c => c.Name.Contains(entityQuery.Name));
            }

            if (!entityQuery.Pinyin.IsNullOrEmpty())
            {
                q = q.Where(c => c.Pinyin.Contains(entityQuery.Pinyin));
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
