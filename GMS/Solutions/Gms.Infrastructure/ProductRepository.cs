using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        protected override IQueryable<Product> LoadQuery<TQ>(TQ query)
        {
        //    public int OrderId { get; set; }
        //public string Name { get; set; }
        //public GlassType GlassType { get; set; }
        //public Thickness Thickness { get; set; }

            IQueryable<Product> q = base.LoadQuery(query);
            var productQuery = query as ProductQuery;
            if (productQuery == null) return q;

            if (productQuery.OrderId.HasValue)
            {
                q = q.Where(c => c.Order.Id == productQuery.OrderId);
            }

            if (productQuery.Name.NotNullAndEmpty())
                q = q.Where(c => c.Name.Contains(productQuery.Name));

            if (productQuery.GlassType.HasValue)
            {
                q = q.Where(c => c.GlassType.Id == productQuery.GlassType);
            }

            if (productQuery.Thickness.HasValue)
            {
                q = q.Where(c => c.Thickness == productQuery.Thickness);
            }

            
            return q;
        }
        // public override void Delete(Product entity)
        //{
        //    if (entity.ProductCures != null)
        //    {
        //        foreach (var productCure in entity.ProductCures)
        //        {
        //            this.Session.Delete(productCure);
        //        }
        //    }
        //    base.Delete(entity);
        //}
    }
}
