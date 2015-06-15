using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    public class RoleAuth : Entity
    {
        public virtual string Role { get; set; }
        public virtual AuthType AuthType { get; set; }
        public virtual int Auths { get; set; }
    }

}
