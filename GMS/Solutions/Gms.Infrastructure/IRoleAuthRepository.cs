using Gms.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gms.Infrastructure
{
    public interface IRoleAuthRepository:IRepositoryBase<RoleAuth>
    {
        IList<RoleAuth> GetBy(string role);
        RoleAuth GetBy(string role, AuthType authType);
        bool IsAuthorized(string role, AuthType authType, ActionPoint point);
        bool IsAuthorized(RoleAuth roleAuth, ActionPoint point);
    }
}
