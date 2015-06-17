using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 商品出库
    /// </summary>
    public class StoreOut : Entity
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
        /// 客户
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 业务员
        /// </summary>
        public virtual User Seller { get; set; }

        /// <summary>
        /// 出库类型
        /// 销售出库|其他出库
        /// </summary>
        public virtual CommonCode StoreOutType { get; set; }

        /// <summary>
        /// 结算账户
        /// </summary>
        public virtual Account Account { get; set; }

        /// <summary>
        /// 本次应收款
        /// </summary>
        public virtual decimal Amount { get; set; }

        /// <summary>
        /// 本次收款
        /// </summary>
        public virtual decimal AmountReceipt { get; set; }

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
