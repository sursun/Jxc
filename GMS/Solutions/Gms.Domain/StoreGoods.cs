using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    public abstract class StoreGoods : Entity
    {
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
        /// 新建商品时，商品的期初设置
        /// </summary>
        public virtual Boolean BasicInfo { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }
    }

    public class StoreGoodsQuery : QueryBase
    {
        /// <summary>
        /// 商品
        /// </summary>
        public int? GoodsId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public Range<decimal?> Quantity { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public Range<decimal?> Price { get; set; }

        /// <summary>
        /// 总额
        /// </summary>
        public Range<decimal?> TotalAomount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }
    }
}
