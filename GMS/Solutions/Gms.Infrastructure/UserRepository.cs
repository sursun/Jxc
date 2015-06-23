using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class UserRepository : RepositoryBase<User>,IUserRepository
    {
        protected override IQueryable<User> LoadQuery<TQ>(TQ query)
        {
            IQueryable<User> q = base.LoadQuery(query);
            var entityQuery = query as UserQuery;
            if (entityQuery == null) return q;

            if (!entityQuery.LoginName.IsNullOrEmpty())
            {
                q = q.Where(c => c.LoginName.Contains(entityQuery.LoginName));
            }

            if (entityQuery.DepartmentId.HasValue)
            {
                q = q.Where(c => c.Department.Id == entityQuery.DepartmentId);
            }

            if (!entityQuery.DepartmentName.IsNullOrEmpty())
            {
                q = q.Where(c => c.Department.Name.Contains(entityQuery.DepartmentName));
            }

            if (!entityQuery.Duty.IsNullOrEmpty())
            {
                q = q.Where(c => c.Duty.Contains(entityQuery.Duty));
            }

            if (!entityQuery.RealName.IsNullOrEmpty())
            {
                q = q.Where(c => c.RealName.Contains(entityQuery.RealName));
            }

            if (!entityQuery.Pinyin.IsNullOrEmpty())
            {
                q = q.Where(c => c.Pinyin.Contains(entityQuery.Pinyin));
            }

            if (!entityQuery.NickName.IsNullOrEmpty())
            {
                q = q.Where(c => c.NickName.Contains(entityQuery.NickName));
            }

            if (entityQuery.Gender.HasValue)
            {
                q = q.Where(c => c.Gender == entityQuery.Gender);
            }

            if (!entityQuery.IdCard.IsNullOrEmpty())
            {
                q = q.Where(c => c.IdCard.Contains(entityQuery.IdCard));
            }

            if (entityQuery.EntryDate != null)
            {
                if (entityQuery.EntryDate.Start.HasValue)
                {
                    q = q.Where(c => c.EntryDate >= entityQuery.EntryDate.Start);
                }

                if (entityQuery.EntryDate.End.HasValue)
                {
                    q = q.Where(c => c.EntryDate < entityQuery.EntryDate.End);
                }
            }

            if (!entityQuery.Mobile.IsNullOrEmpty())
            {
                q = q.Where(c => c.Mobile.Contains(entityQuery.Mobile));
            }
            
            if (entityQuery.EmployeeType.HasValue)
            {
                q = q.Where(c => c.EmployeeType == entityQuery.EmployeeType);
            }

            if (entityQuery.EmployeeStatus.HasValue)
            {
                q = q.Where(c => c.EmployeeStatus == entityQuery.EmployeeStatus);
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

        public User Get(string loginName)
        {
            return Query.Where(c => c.LoginName.Equals(loginName)).FirstOrDefault();
        }

        public User Get(Guid membershipId)
        {
            return Query.Where(c => c.MemberShipId.Equals(membershipId)).FirstOrDefault();
        }
    }
}
