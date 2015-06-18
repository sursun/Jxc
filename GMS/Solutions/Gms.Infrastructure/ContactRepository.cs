using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        protected override IQueryable<Contact> LoadQuery<TQ>(TQ query)
        {
            IQueryable<Contact> q = base.LoadQuery(query);
            var entityQuery = query as ContactQuery;
            if (entityQuery == null) return q;

            if (entityQuery.RelationPersonId.HasValue)
            {
                q = q.Where(c => c.RelationPerson.Id == entityQuery.RelationPersonId);
            }

            if (!entityQuery.Name.IsNullOrEmpty())
            {
                q = q.Where(c => c.Name.Contains(entityQuery.Name));
            }

            if (entityQuery.Gender.HasValue)
            {
                q = q.Where(c => c.Gender == entityQuery.Gender);
            }

            if (!entityQuery.CardNo.IsNullOrEmpty())
            {
                q = q.Where(c => c.CardNo.Contains(entityQuery.CardNo));
            }

            if (!entityQuery.Mobile.IsNullOrEmpty())
            {
                q = q.Where(c => c.Mobile.Contains(entityQuery.Mobile));
            }

            if (entityQuery.IsDefault.HasValue)
            {
                q = q.Where(c => c.IsDefault == entityQuery.IsDefault);
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
