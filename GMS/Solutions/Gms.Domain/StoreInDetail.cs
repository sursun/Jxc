using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 商品入库 详单
    /// </summary>
    public class StoreInDetail : StoreGoods
    {
        /// <summary>
        /// 入库单
        /// </summary>
        public virtual StoreIn StoreIn { get; set; }

    }

    public class StoreInDetailQuery : StoreGoodsQuery
    {
        /// <summary>
        /// 入库单
        /// </summary>
        public int? StoreInId { get; set; }

    }
}
