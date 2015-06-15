using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class EquiOutRepository : RepositoryBase<EquiOut>, IEquiOutRepository
    {
        protected override IQueryable<EquiOut> LoadQuery<TQ>(TQ query)
        {
            IQueryable<EquiOut> q = base.LoadQuery(query);
            var entityQuery = query as EquiOutQuery;
            if (entityQuery == null) return q;

            if (entityQuery.EquiStoreOutId.HasValue)
            {
                q = q.Where(c => c.EquiStoreOut.Id == entityQuery.EquiStoreOutId);
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

        public IList<EquiOut> GetBy(int equiStoreOutId)
        {
            return Query.Where(c => c.EquiStoreOut.Id == equiStoreOutId).ToList();
        }
    }
}
