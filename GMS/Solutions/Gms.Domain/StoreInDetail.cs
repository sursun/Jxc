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
    public class StoreInDetail : Entity
    {
        /// <summary>
        /// 入库单
        /// </summary>
        public virtual StoreIn StoreIn { get; set; }

        /// <summary>
        /// 商品
        /// </summary>
        public virtual Goods Goods { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public virtual decimal Quantity { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public virtual decimal Price { get; set; }

        /// <summary>
        /// 总额
        /// </summary>
        public virtual decimal TotalAomount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }
        
    }
}
