using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 采购退货单
    /// </summary>
    public class PurchaseReturn : StoreAlter
    {

        /// <summary>
        /// 供应商
        /// </summary>
        public virtual Supplier Supplier { get; set; }

        /// <summary>
        /// 采购员
        /// </summary>
        public virtual User Buyer { get; set; }

        /// <summary>
        /// 出库类型
        /// 采购退货出库
        /// </summary>
        public virtual CommonCode StoreOutType { get; set; }
        
        /// <summary>
        /// 本次付款
        /// </summary>
        public virtual decimal AmountPay { get; set; }
  
    }

    public class PurchaseReturnQuery : StoreAlterQuery
    {
        /// <summary>
        /// 供应商
        /// Id
        /// </summary>
        public int? SupplierId { get; set; }

        /// <summary>
        /// 供应商
        /// 名称
        /// </summary>
        public String SupplierName { get; set; }

        /// <summary>
        /// 采购员
        /// Id
        /// </summary>
        public int? BuyerId { get; set; }

        /// <summary>
        /// 采购员
        /// 姓名
        /// </summary>
        public String BuyerName { get; set; }

        /// <summary>
        /// 出库类型
        /// 采购退货出库
        /// </summary>
        public int? StoreOutTypeId { get; set; }

        /// <summary>
        /// 本次付款
        /// </summary>
        public Range<decimal?> AmountPay { get; set; }
    }
}
