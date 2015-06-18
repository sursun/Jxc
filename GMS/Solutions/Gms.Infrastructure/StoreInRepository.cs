using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class StoreInRepository : RepositoryBase<StoreIn>, IStoreInRepository
    {
        protected override IQueryable<StoreIn> LoadQuery<TQ>(TQ query)
        {
            IQueryable<StoreIn> q = base.LoadQuery(query);
            var entityQuery = query as StoreInQuery;
            if (entityQuery == null) return q;

            if (entityQuery.EquiStoreInId.HasValue)
            {
                q = q.Where(c => c.EquiStoreIn.Id == entityQuery.EquiStoreInId);
            }

            if (entityQuery.EquipmentId.HasValue)
            {
                q = q.Where(c => c.Equipment.Id == entityQuery.EquipmentId);
            }

            if (entityQuery.EquipmentName.NotNullAndEmpty())
            {
                q = q.Where(c => c.Equipment.Name.Contains(entityQuery.EquipmentName));
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

            return q;
        }
        
    }
}
