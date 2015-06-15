using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class UserRepository : RepositoryBase<User>,IUserRepository
    {
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
