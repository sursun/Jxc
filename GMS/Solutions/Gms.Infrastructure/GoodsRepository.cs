using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class GoodsRepository : RepositoryBase<Goods>, IGoodsRepository
    {
        protected override IQueryable<Goods> LoadQuery<TQ>(TQ query)
        {
            IQueryable<Goods> q = base.LoadQuery(query);
            var entityQuery = query as GoodsQuery;
            if (entityQuery == null) return q;

            if (!entityQuery.CodeNo.IsNullOrEmpty())
            {
                q = q.Where(c => c.CodeNo.Contains(entityQuery.CodeNo));
            }

            if (!entityQuery.BarCode.IsNullOrEmpty())
            {
                q = q.Where(c => c.BarCode.Contains(entityQuery.BarCode));
            }

            if (!entityQuery.Name.IsNullOrEmpty())
            {
                q = q.Where(c => c.Name.Contains(entityQuery.Name));
            }

            if (!entityQuery.Pinyin.IsNullOrEmpty())
            {
                q = q.Where(c => c.Pinyin.Contains(entityQuery.Pinyin));
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
            
            if (entityQuery.IsMinWarning.HasValue)
            {
                q = q.Where(c => c.IsMinWarning == entityQuery.IsMinWarning);
            }

            if (entityQuery.IsMaxWarning.HasValue)
            {
                q = q.Where(c => c.IsMaxWarning == entityQuery.IsMaxWarning);
            }

            if (entityQuery.BrandId.HasValue)
            {
                q = q.Where(c => c.Brand.Id == entityQuery.BrandId);
            }

            if (entityQuery.DisplayStandsId.HasValue)
            {
                q = q.Where(c => c.DisplayStands.Id == entityQuery.DisplayStandsId);
            }

            if (entityQuery.IsBargin.HasValue)
            {
                q = q.Where(c => c.IsBargin == entityQuery.IsBargin);
            }

            if (entityQuery.IsFreePrice.HasValue)
            {
                q = q.Where(c => c.IsFreePrice == entityQuery.IsFreePrice);
            }

            if (entityQuery.PointBase != null)
            {
                if (entityQuery.PointBase.Start.HasValue)
                {
                    q = q.Where(c => c.PointBase >= entityQuery.PointBase.Start);
                }

                if (entityQuery.PointBase.End.HasValue)
                {
                    q = q.Where(c => c.PointBase < entityQuery.PointBase.End);
                }
            }

            if (entityQuery.GoodsStatus.HasValue)
            {
                q = q.Where(c => c.GoodsStatus == entityQuery.GoodsStatus);
            }

            if (!entityQuery.Note.IsNullOrEmpty())
            {
                q = q.Where(c => c.Note.Contains(entityQuery.Note));
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
