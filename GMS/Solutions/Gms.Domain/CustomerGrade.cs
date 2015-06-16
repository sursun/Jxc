using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 客户等级
    /// </summary>
    public class CustomerGrade : Entity
    {
        /// <summary>
        /// 编码
        /// </summary>
        public virtual String CodeNo { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        public virtual decimal Discount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }
 
    }
}
