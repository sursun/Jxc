using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    public class GoodsPriceAlter:Entity
    {
        /// <summary>
        /// 商品
        /// </summary>
        public virtual Goods Goods { get; set; }

        /// <summary>
        /// 修改前价格
        /// </summary>
        public virtual decimal OldPrice { get; set; }

        /// <summary>
        /// 新价格
        /// </summary>
        public virtual decimal NewPrice { get; set; }

        /// <summary>
        /// 原库存量
        /// </summary>
        public virtual decimal Quantity { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public virtual User Auditor { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public virtual DateTime AuditTime { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public virtual AuditState AuditState { get; set; }

        /// <summary>
        /// 审核说明
        /// </summary>
        public virtual String AuditNote { get; set; }

        /// <summary>
        /// 生效日期
        /// </summary>
        public virtual DateTime StartTime { get; set; }

        /// <summary>
        /// 登记人
        /// </summary>
        public virtual User Creator { get; set; }

        /// <summary>
        /// 登记日期
        /// </summary>
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }
    }
}
