using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 商品入库
    /// </summary>
    public class StoreIn : Entity
    {
        /// <summary>
        /// 票号
        /// </summary>
        public virtual String CodeNo { get; set; }

        /// <summary>
        /// 单据编号
        /// </summary>
        public virtual String OrderCode { get; set; }

        /// <summary>
        /// 单据日期
        /// </summary>
        public virtual DateTime OrderTime { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public virtual CommonCode Store { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        public virtual Supplier Supplier { get; set; }

        /// <summary>
        /// 采购员
        /// </summary>
        public virtual User Buyer { get; set; }

        /// <summary>
        /// 入库类型
        /// 采购入库|其他入库
        /// </summary>
        public virtual CommonCode StoreInType { get; set; }

        /// <summary>
        /// 结算账户
        /// </summary>
        public virtual Account Account { get; set; }

        /// <summary>
        /// 本次应付款
        /// </summary>
        public virtual decimal Amount { get; set; }

        /// <summary>
        /// 本次付款
        /// </summary>
        public virtual decimal AmountPay { get; set; }

        /// <summary>
        /// 本次欠款
        /// </summary>
        public virtual decimal Debt { get; set; }

        /// <summary>
        /// 付款人
        /// </summary>
        public virtual String Payer { get; set; }

        /// <summary>
        /// 收款人
        /// </summary>
        public virtual String Payee { get; set; }

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
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }

        /// <summary>
        /// 登记人
        /// </summary>
        public virtual User Creator { get; set; }

        /// <summary>
        /// 登记日期
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
        
    }
}
