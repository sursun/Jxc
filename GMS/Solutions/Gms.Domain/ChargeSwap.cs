using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 流转记账
    /// </summary>
    public class ChargeSwap : AuditBase
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
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }
    }

    /// <summary>
    /// 流转记账
    /// </summary>
    public class ChargeSwapQuery : AuditBaseQuery
    {
        /// <summary>
        /// 源账户
        /// </summary>
        public int? OrigAccountId { get; set; }

        /// <summary>
        /// 目的账户
        /// </summary>
        public int? DestAccountId { get; set; }
        
        /// <summary>
        /// 记账金额
        /// </summary>
        public Range<decimal?> Amount { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }
    }
}
