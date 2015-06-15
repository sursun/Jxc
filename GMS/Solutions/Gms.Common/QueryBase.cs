using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gms.Common
{
    public class QueryBase
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }

        /// <summary>
        /// 例如" UserName desc,CreateTime asc"
        /// </summary>
        public string OrderBy { get; set; }
    }
}
