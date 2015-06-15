using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public class RoleAuthRepository:RepositoryBase<RoleAuth>,IRoleAuthRepository
    {
        public IList<RoleAuth> GetBy(string role)
        {
            return Query.Where(c => c.Role.Equals(role)).ToList();
        }

        public RoleAuth GetBy(string role, AuthType authType)
        {
            return Query.Where(c => (c.Role.Equals(role) && c.AuthType == authType)).FirstOrDefault();
        }

        public bool IsAuthorized(string role, AuthType authType, ActionPoint point)
        {
            bool bRet = false;

            var authRole = Query.Where(c =>(c.Role.Equals(role) && c.AuthType == authType ) ).FirstOrDefault();
            if (authRole != null)
            {
                if ((authRole.Auths &(int)point) != 0)
                {
                    bRet = true;
                }
            }

            return bRet;
        }

        public bool IsAuthorized(RoleAuth roleAuth, ActionPoint point)
        {
            bool bRet = false;

            if (roleAuth == null)
            {
                return bRet;
            }

            if ((roleAuth.Auths & (int)point) != 0)
            {
                bRet = true;
            }

            return bRet;
        }
    }
}
