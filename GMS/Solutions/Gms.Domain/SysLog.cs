using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
}
