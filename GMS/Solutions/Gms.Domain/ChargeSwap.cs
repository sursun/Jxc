using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 流转记账
    /// </summary>
    public class ChargeSwap:Entity
    {
        /// <summary>
        /// 源账户
        /// </summary>
        public virtual Account OrigAccount { get; set; }

        /// <summary>
        /// 目的账户
        /// </summary>
        public virtual Account DestAccount { get; set; }
        
        /// <summary>
        /// 变化前
        /// 源账户金额
        /// </summary>
        public virtual decimal OrigAmount { get; set; }

        /// <summary>
        /// 变化前
        /// 目的账户金额
        /// </summary>
        public virtual decimal DestAmount { get; set; }

        /// <summary>
        /// 记账金额
        /// </summary>
        public virtual decimal Amount { get; set; }

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
