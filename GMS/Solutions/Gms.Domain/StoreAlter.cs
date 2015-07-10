using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 商品出入库
    /// </summary>
    public abstract class StoreAlter : AuditBase
    {
        public StoreAlter()
        {
            this.CodeNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            this.OrderTime = DateTime.Now;
        }

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
        /// 结算账户
        /// </summary>
        public virtual Account Account { get; set; }

        /// <summary>
        /// 本次应付(收)款
        /// </summary>
        public virtual decimal Amount { get; set; }

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
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }
        
    }

    public class StoreAlterQuery : AuditBaseQuery
    {
        /// <summary>
        /// 票号
        /// </summary>
        public String CodeNo { get; set; }

        /// <summary>
        /// 单据编号
        /// </summary>
        public String OrderCode { get; set; }

        /// <summary>
        /// 单据日期
        /// </summary>
        public Range<DateTime?>  OrderTime { get; set; }

        /// <summary>
        /// 结算账户
        /// Id
        /// </summary>
        public int? AccountId { get; set; }

        /// <summary>
        /// 本次应付(收)款
        /// </summary>
        public Range<decimal?> Amount { get; set; }
        
        /// <summary>
        /// 本次欠款
        /// </summary>
        public Range<decimal?> Debt { get; set; }

        /// <summary>
        /// 付款人
        /// </summary>
        public String Payer { get; set; }

        /// <summary>
        /// 收款人
        /// </summary>
        public String Payee { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }

    }
}
