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
    public class GoodsTransferDetail : Entity
    {
        /// <summary>
        /// 商品调拨
        /// </summary>
        public virtual GoodsTransfer GoodsTransfer { get; set; }
        
        /// <summary>
        /// 商品
        /// </summary>
        public virtual Goods Goods { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public virtual decimal Quantity { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }


    }
}
