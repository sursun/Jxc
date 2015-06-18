using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 系统日志
    /// </summary>
    public class SysLog : Entity
    {
        /// <summary>
        /// 操作人
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public virtual String Content { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
 
    }

    public class SysLogQuery : QueryBase
    {
        /// <summary>
        /// 操作人
        /// Id
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 操作人
        /// 姓名
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public String Content { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public Range<DateTime?> CreateTime { get; set; }

    }
}
