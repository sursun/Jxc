using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class GoodsTypeRepository : RepositoryBase<GoodsType>, IGoodsTypeRepository
    {
        protected override IQueryable<GoodsType> LoadQuery<TQ>(TQ query)
        {
            IQueryable<GoodsType> q = base.LoadQuery(query);
            var entityQuery = query as GoodsTypeQuery;
            if (entityQuery == null) return q;

            if (entityQuery.GoodsId.HasValue)
            {
                q = q.Where(c => c.Goods.Id == entityQuery.GoodsId);
            }

            if (entityQuery.TypeId.HasValue)
            {
                q = q.Where(c => c.Type.Id == entityQuery.TypeId);
            }
            
            return q;
        }

        public IList<GoodsType> GetGoodsTypes(int id)
        {
            return Query.Where(c => (c.Goods.Id == id)).ToList();
        }
    }
}
