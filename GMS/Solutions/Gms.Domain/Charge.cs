using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 收支记账
    /// </summary>
    public class Charge : AuditBase
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
        /// 是否自动记账？
        /// </summary>
        public virtual Yesno AutoCreate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }
    }

    public class ChargeQuery : AuditBaseQuery
    {
        /// <summary>
        /// 记账账户
        /// </summary>
        public int? AccountId { get; set; }

        /// <summary>
        /// 收入还是支出？
        /// </summary>
        public CommonCodeType? ChargeTypeFlag { get; set; }

        /// <summary>
        /// 收支类型
        /// </summary>
        public int? ChargeTypeId { get; set; }

        /// <summary>
        /// 记账金额
        /// </summary>
        public Range<decimal?> Amount { get; set; }
        
        /// <summary>
        /// 经手人
        /// Id
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 经手人
        /// 姓名
        /// </summary>
        public String UserName { get; set; }
        
        /// <summary>
        /// 是否自动记账？
        /// </summary>
        public Yesno? AutoCreate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }
    }
}
