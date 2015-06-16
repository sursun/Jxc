using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class EquipmentRepository : RepositoryBase<Goods>, IEquipmentRepository
    {
        protected override IQueryable<Goods> LoadQuery<TQ>(TQ query)
        {
            IQueryable<Goods> q = base.LoadQuery(query);
            var entityQuery = query as EquipmentQuery;
            if (entityQuery == null) return q;

            if (entityQuery.IsWarning.HasValue && entityQuery.IsWarning == true)
            {
                q = q.Where(c => (c.Quantity <= c.MinQuantity));
            }

            if (entityQuery.EquiType.HasValue)
            {
                q = q.Where(c => c.EquiType.Id == entityQuery.EquiType);
            }

            if (entityQuery.Name.NotNullAndEmpty())
            {
                q = q.Where(c => c.Name.Contains(entityQuery.Name));
            }

            if (entityQuery.Model.NotNullAndEmpty())
            {
                q = q.Where(c => c.Model.Contains(entityQuery.Model));
            }

            if (entityQuery.Quantity != null)
            {
                if (entityQuery.Quantity.Start.HasValue)
                {
                    q = q.Where(c => c.Quantity >= entityQuery.Quantity.Start);
                }

                if (entityQuery.Quantity.End.HasValue)
                {
                    q = q.Where(c => c.Quantity < entityQuery.Quantity.End);
                }
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
            
            if (entityQuery.Note.NotNullAndEmpty())
            {
                q = q.Where(c => c.Note.Contains(entityQuery.Note));
            }

            return q;
        }
    }
}
