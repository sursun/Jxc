using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 商品出库 详单
    /// </summary>
    public class StoreOutDetail : StoreGoods
    {
        /// <summary>
        /// 出库单
        /// </summary>
        public virtual StoreOut StoreOut { get; set; }
        
    }
    
    public class StoreOutDetailQuery : StoreGoodsQuery 
    {
        /// <summary>
        /// 出库单
        /// </summary>
        public int? StoreOutId { get; set; }
        
    }
}
