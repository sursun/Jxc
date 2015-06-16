using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 供应商
    /// </summary>
    public class Supplier : LinkMan
    {
        public Supplier()
        {
            LinkmanType = LinkmanType.供应商;
        }
    }
}
