using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private IProductRepository productRepository = new ProductRepository();
        protected override IQueryable<Order> LoadQuery<TQ>(TQ query)
        {

            IQueryable<Order> q = base.LoadQuery(query);
            var orderQuery = query as OrderQuery;
            if (orderQuery == null) return q;
            if (orderQuery.CodeNo.NotNullAndEmpty())
                q = q.Where(c => c.CodeNo.Contains(orderQuery.CodeNo));
            if (orderQuery.CustomerName.NotNullAndEmpty())
                q = q.Where(c => c.Customer.Name.Contains(orderQuery.CustomerName));
            if (orderQuery.CustomerMobile.NotNullAndEmpty())
                q = q.Where(c => c.Customer.Mobile.Contains(orderQuery.CustomerMobile));

            if (orderQuery.TotalPrice != null)
            {
                if (orderQuery.TotalPrice.Start.HasValue)
                {
                    q = q.Where(c => c.TotalPrice >= orderQuery.TotalPrice.Start);
                }

                if (orderQuery.TotalPrice.End.HasValue)
                {
                    q = q.Where(c => c.TotalPrice <= orderQuery.TotalPrice.End);
                }
            }

            if (orderQuery.RealTotalPrice != null)
            {
                if (orderQuery.RealTotalPrice.Start.HasValue)
                {
                    q = q.Where(c => c.RealTotalPrice >= orderQuery.RealTotalPrice.Start);
                }

                if (orderQuery.RealTotalPrice.End.HasValue)
                {
                    q = q.Where(c => c.RealTotalPrice <= orderQuery.RealTotalPrice.End);
                }
            }

            if (orderQuery.ModifyTime != null)
            {
                if (orderQuery.ModifyTime.Start.HasValue)
                {
                    q = q.Where(c => c.ModifyTime >= orderQuery.ModifyTime.Start);
                }

                if (orderQuery.ModifyTime.End.HasValue)
                {
                    q = q.Where(c => c.ModifyTime <= orderQuery.ModifyTime.End);
                }
            }

            if (orderQuery.CreateTime != null)
            {
                if (orderQuery.CreateTime.Start.HasValue)
                {
                    q = q.Where(c => c.CreateTime >= orderQuery.CreateTime.Start);
                }

                if (orderQuery.CreateTime.End.HasValue)
                {
                    q = q.Where(c => c.CreateTime <= orderQuery.CreateTime.End);
                }
            }

            return q;
        }

        public override void Delete(Order entity)
        {
            if (entity.Products != null)
            {
                foreach (var product in entity.Products)
                {
                    this.productRepository.Delete(product);
                }
            }
            base.Delete(entity);
        }
    }
}
