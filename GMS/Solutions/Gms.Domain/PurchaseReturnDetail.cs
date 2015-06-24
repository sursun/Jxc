using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 采购退货单 详单
    /// </summary>
    public class PurchaseReturnDetail : StoreGoods
    {
        /// <summary>
        /// 采购退货单
        /// </summary>
        public virtual PurchaseReturn PurchaseReturn { get; set; }

    }

    public class PurchaseReturnDetailQuery : StoreGoodsQuery
    {
        /// <summary>
        /// 采购退货单
        /// </summary>
        public int? PurchaseReturnId { get; set; }

    }
}
