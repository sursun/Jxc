using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public interface IUserRepository:IRepositoryBase<User>
    {
        User Get(string loginName);

        User Get(Guid membershipId);
    }
}
