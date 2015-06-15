using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class ProductCureRepository : RepositoryBase<ProductCure>, IProductCureRepository
    {
        protected override IQueryable<ProductCure> LoadQuery<TQ>(TQ query)
        {

            IQueryable<ProductCure> q = base.LoadQuery(query);
            var entityQuery = query as ProductCureQuery;
            if (entityQuery == null) return q;

            if (entityQuery.OrderId.HasValue)
            {
                q = q.Where(c => c.Order.Id == entityQuery.OrderId);
            }

            if (entityQuery.CureTypeId.HasValue)
            {
                q = q.Where(c => c.CureType.Id == entityQuery.CureTypeId);
            }


            if (!entityQuery.UserName.IsNullOrEmpty())
            {
                q = q.Where(c => c.User.LoginName.Contains(entityQuery.UserName));
            }

            if (!entityQuery.CheckUserName.IsNullOrEmpty())
            {
                q = q.Where(c => c.CheckUser.LoginName.Contains(entityQuery.CheckUserName));
            }

            if (entityQuery.StartTime != null)
            {
                if (entityQuery.StartTime.Start.HasValue)
                {
                    q = q.Where(c => c.StartTime >= entityQuery.StartTime.Start);
                }

                if (entityQuery.StartTime.End.HasValue)
                {
                    q = q.Where(c => c.StartTime <= entityQuery.StartTime.End);
                }
            }

            if (entityQuery.EndTime != null)
            {
                if (entityQuery.EndTime.Start.HasValue)
                {
                    q = q.Where(c => c.EndTime >= entityQuery.EndTime.Start);
                }

                if (entityQuery.EndTime.End.HasValue)
                {
                    q = q.Where(c => c.EndTime <= entityQuery.EndTime.End);
                }
            }

            return q;
        }
    }
}
