using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 商品出库
    /// </summary>
    public class StoreOut : StoreAlter
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
        /// 销售出库|其他出库
        /// </summary>
        public virtual CommonCode StoreOutType { get; set; }
        
        /// <summary>
        /// 本次收款
        /// </summary>
        public virtual decimal AmountReceipt { get; set; }
 
    }

    public class StoreOutQuery : StoreAlterQuery
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
        /// 出库类型
        /// 销售出库|其他出库
        /// Id
        /// </summary>
        public int? StoreOutTypeId { get; set; }

        /// <summary>
        /// 本次收款
        /// </summary>
        public Range<decimal?> AmountReceipt { get; set; }

    }
}
