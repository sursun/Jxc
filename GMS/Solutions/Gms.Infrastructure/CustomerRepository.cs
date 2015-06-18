using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class CustomerRepository:RepositoryBase<Customer>,ICustomerRepository
    {
   
        protected override IQueryable<Customer> LoadQuery<TQ>(TQ query)
        {

            IQueryable<Customer> q = base.LoadQuery(query);
            var entityQuery = query as CustomerQuery;
            if (entityQuery == null) return q;

            if (entityQuery.CustomerTypeId.HasValue)
            {
                q = q.Where(c => c.CustomerType.Id==entityQuery.CustomerTypeId);
            }

            if (entityQuery.CustomerGradeId.HasValue)
            {
                q = q.Where(c => c.CustomerGrade.Id == entityQuery.CustomerGradeId);
            }

            if (entityQuery.ShoukuanQc != null)
            {
                if (entityQuery.ShoukuanQc.Start.HasValue)
                {
                    q = q.Where(c => c.ShoukuanQc >= entityQuery.ShoukuanQc.Start);
                }

                if (entityQuery.ShoukuanQc.End.HasValue)
                {
                    q = q.Where(c => c.ShoukuanQc < entityQuery.ShoukuanQc.End);
                }
            }

            if (entityQuery.ShoukuanYing != null)
            {
                if (entityQuery.ShoukuanYing.Start.HasValue)
                {
                    q = q.Where(c => c.ShoukuanYing >= entityQuery.ShoukuanYing.Start);
                }

                if (entityQuery.ShoukuanYing.End.HasValue)
                {
                    q = q.Where(c => c.ShoukuanYing < entityQuery.ShoukuanYing.End);
                }
            }

            if (entityQuery.ShoukuanYu != null)
            {
                if (entityQuery.ShoukuanYu.Start.HasValue)
                {
                    q = q.Where(c => c.ShoukuanYu >= entityQuery.ShoukuanYu.Start);
                }

                if (entityQuery.ShoukuanYu.End.HasValue)
                {
                    q = q.Where(c => c.ShoukuanYu < entityQuery.ShoukuanYu.End);
                }
            }

            if (entityQuery.AllowDebt.HasValue)
            {
                q = q.Where(c => c.AllowDebt == entityQuery.AllowDebt);
            }

            if (entityQuery.Debt != null)
            {
                if (entityQuery.Debt.Start.HasValue)
                {
                    q = q.Where(c => c.Debt >= entityQuery.Debt.Start);
                }

                if (entityQuery.Debt.End.HasValue)
                {
                    q = q.Where(c => c.Debt < entityQuery.Debt.End);
                }
            }

            if (entityQuery.Point != null)
            {
                if (entityQuery.Point.Start.HasValue)
                {
                    q = q.Where(c => c.Point >= entityQuery.Point.Start);
                }

                if (entityQuery.Point.End.HasValue)
                {
                    q = q.Where(c => c.Point < entityQuery.Point.End);
                }
            }
            
            return q;
        }
    }
}
