using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 销售退货单
    /// </summary>
    public class SellReturn : StoreAlter
    {
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
        /// 销售退货
        /// </summary>
        public virtual CommonCode StoreInType { get; set; }
        
        /// <summary>
        /// 本次收款
        /// </summary>
        public virtual decimal AmountReceipt { get; set; }
 
    }

    public class SellReturnQuery : StoreAlterQuery
    {
        /// <summary>
        /// 客户
        /// Id
        /// </summary>
        public int? CustomerId { get; set; }

        /// <summary>
        /// 客户
        /// 名称
        /// </summary>
        public String CustomerName { get; set; }

        /// <summary>
        /// 业务员
        /// Id
        /// </summary>
        public int? SellerId { get; set; }

        /// <summary>
        /// 业务员
        /// 姓名
        /// </summary>
        public String SellerName { get; set; }

        /// <summary>
        /// 入库类型
        /// 销售退货
        /// Id
        /// </summary>
        public int? StoreInTypeId { get; set; }

        /// <summary>
        /// 本次收款
        /// </summary>
        public Range<decimal?> AmountReceipt { get; set; }

    }
}
