using Gms.Common;
using Gms.Domain.Attribute;
using SharpArch.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gms.Domain
{
    /// <summary>
    /// 单位信息
    /// </summary>
    public class Company:Entity
    {
        /// <summary>
        /// 单位编号
        /// </summary>
        public virtual String CodeNo { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// 注册信息
        /// </summary>
        [FieldLength(4000)]
        public virtual String RegKey { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }
    }
  
}
