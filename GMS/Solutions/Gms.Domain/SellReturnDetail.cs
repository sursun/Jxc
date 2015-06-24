using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 销售退货单 详单
    /// </summary>
    public class SellReturnDetail : StoreGoods
    {
        /// <summary>
        /// 销售退货单
        /// </summary>
        public virtual SellReturn SellReturn { get; set; }
        
    }

    public class SellReturnDetailQuery : StoreGoodsQuery 
    {
        /// <summary>
        /// 销售退货单
        /// </summary>
        public int? SellReturnId { get; set; }
        
    }
}
