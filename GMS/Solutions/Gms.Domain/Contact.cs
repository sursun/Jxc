using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    public class Contact:Entity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public virtual String CardNo { get; set; }
    }
}
