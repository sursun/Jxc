using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 收支记账
    /// </summary>
    public class Charge:Entity
    {
        /// <summary>
        /// 记账账户
        /// </summary>
        public virtual Account Account { get; set; }

        /// <summary>
        /// 记账前
        /// 账户金额
        /// </summary>
        public virtual decimal OldAmount { get; set; }

        /// <summary>
        /// 收支类型
        /// </summary>
        public virtual CommonCode ChargeType { get; set; }

        /// <summary>
        /// 记账金额
        /// </summary>
        public virtual decimal Amount { get; set; }

        /// <summary>
        /// 经手人
        /// </summary>
        public virtual User User { get; set; }

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
        /// 登记人
        /// </summary>
        public virtual User Creator { get; set; }

        /// <summary>
        /// 登记日期
        /// </summary>
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 是否自动记账？
        /// </summary>
        public virtual Boolean AutoCreate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }
    }
}
