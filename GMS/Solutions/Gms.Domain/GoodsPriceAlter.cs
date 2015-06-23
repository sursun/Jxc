using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using Gms.Domain.Attribute;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    public class GoodsPriceAlter:AuditBase
    {
        /// <summary>
        /// 商品
        /// </summary>
        public virtual Goods Goods { get; set; }

        /// <summary>
        /// 修改前价格
        /// </summary>
        public virtual decimal OldPrice { get; set; }

        /// <summary>
        /// 新价格
        /// </summary>
        public virtual decimal NewPrice { get; set; }

        /// <summary>
        /// 修改差额
        /// </summary>
        [NotMap]
        public virtual decimal Balance {
            get
            {
                return Math.Abs( NewPrice - OldPrice);
            }
        }

        /// <summary>
        /// 修改差额比
        /// </summary>
        [NotMap]
        public virtual decimal BalanceRatio
        {
            get
            {
                decimal nVal = (Balance*100)/OldPrice;
                return nVal/100;
            }
        }

        /// <summary>
        /// 原库存量
        /// </summary>
        public virtual decimal Quantity { get; set; }
        
        /// <summary>
        /// 生效日期
        /// </summary>
        public virtual DateTime StartTime { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }
    }

    public class GoodsPriceAlterQuery : AuditBaseQuery
    {
        /// <summary>
        /// 商品
        /// Id
        /// </summary>
        public int? GoodsId { get; set; }

        /// <summary>
        /// 修改差额
        /// </summary>
        public Range<decimal?> Balance { get; set; }

        /// <summary>
        /// 修改差额比
        /// </summary>
        public Range<decimal?> BalanceRatio { get; set; }

        /// <summary>
        /// 生效日期
        /// </summary>
        public Range<DateTime?>  StartTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }
    }
}
