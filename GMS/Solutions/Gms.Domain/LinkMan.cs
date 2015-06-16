using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 联系人
    /// 客户|供应商
    /// </summary>
    public class LinkMan:Entity
    {
        /// <summary>
        /// 联系人类型
        /// </summary>
        public virtual LinkmanType LinkmanType { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public virtual String CodeNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public virtual String CardNo { get; set; }

        /// <summary>
        /// 添加日期（开户时间）
        /// </summary>
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }
    }
}
