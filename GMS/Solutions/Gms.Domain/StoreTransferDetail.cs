using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 商品调拨 详单
    /// </summary>
    public class StoreTransferDetail : StoreGoods
    {
        /// <summary>
        /// 商品调拨
        /// </summary>
        public virtual StoreTransfer GoodsTransfer { get; set; }

    }
    
    public class StoreTransferDetailQuery : StoreGoodsQuery
    {
        /// <summary>
        /// 商品调拨
        /// </summary>
        public int? GoodsTransferId { get; set; }

    }
}
