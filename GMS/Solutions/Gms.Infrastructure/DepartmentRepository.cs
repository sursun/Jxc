using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        protected override IQueryable<Department> LoadQuery<TQ>(TQ query)
        {
            IQueryable<Department> q = base.LoadQuery(query);
            var entityQuery = query as DepartmentQuery;
            if (entityQuery == null) return q;

            if (entityQuery.ParentId.HasValue)
            {
                q = q.Where(c => c.Parent.Id == entityQuery.ParentId);
            }

            if (!entityQuery.Name.IsNullOrEmpty())
            {
                q = q.Where(c => c.Name.Contains(entityQuery.Name));
            }

            if (!entityQuery.CodeNo.IsNullOrEmpty())
            {
                q = q.Where(c => c.CodeNo.Contains(entityQuery.CodeNo));
            }

            if (entityQuery.Level.HasValue)
            {
                q = q.Where(c => c.Level == entityQuery.Level);
            }

            if (!entityQuery.Note.IsNullOrEmpty())
            {
                q = q.Where(c => c.Note.Contains(entityQuery.Note));
            }
            



            return q;
        }
    }
}
