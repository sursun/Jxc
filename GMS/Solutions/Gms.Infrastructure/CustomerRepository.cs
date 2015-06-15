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
            var customerQuery = query as CustomerQuery;
            if (customerQuery == null) return q;
            if (customerQuery.Name.NotNullAndEmpty())
                q = q.Where(c => c.Name.Contains(customerQuery.Name));
            if (customerQuery.Company.NotNullAndEmpty())
                q = q.Where(c => c.Company.Contains(customerQuery.Company));
            if (customerQuery.Mobile.NotNullAndEmpty())
                q = q.Where(c => c.Mobile.Contains(customerQuery.Mobile));
            if (customerQuery.AllInOne.NotNullAndEmpty())
                q = q.Where(c => (c.Name.Contains(customerQuery.AllInOne) || c.Mobile.Contains(customerQuery.AllInOne)
                    || c.Company.Contains(customerQuery.AllInOne)));
            
            return q;
        }
    }
}
