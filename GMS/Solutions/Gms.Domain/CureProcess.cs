using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 加工过程
    /// </summary>
    public class CureProcess:Entity
    {
        /// <summary>
        /// 过程名称
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// 过程描述，例如：开板=>钻孔=>钢化
        /// </summary>
        public virtual String DescString { get; set; }

        /// <summary>
        /// 加工类型
        /// </summary>
        public virtual IList<CommonCode> CureTypes { get; set; }

        /// <summary>
        /// 按面积计算单价
        /// </summary>
        public virtual decimal AreaPrice { get; set; }

        /// <summary>
        /// 按边长计算单价
        /// </summary>
        public virtual decimal EdgePrice { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }
      
    }
}
