using Gms.Common;
using SharpArch.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gms.Domain
{
    /// <summary>
    /// 库存变化
    /// </summary>
    public class StoreChange:Entity
    {
        /// <summary>
        /// 库存
        /// </summary>
        public virtual GlassStore GlassStore { get; set; }

        /// <summary>
        /// 用途
        /// </summary>
        public virtual GlassUsage GlassUsage { get; set; }

        /// <summary>
        /// 对应订单
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public virtual int Amount { get; set; }

        /// <summary>
        /// 登记员
        /// </summary>
        public virtual User CreateUser { get; set; }

        /// <summary>
        /// 登记日期
        /// </summary>
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }
    }

    public class StoreChangeQuery : QueryBase
    {
        /// <summary>
        /// 玻璃品种
        /// </summary>
        public int? GlassTypeId { get; set; }

        /// <summary>
        /// 厚度
        /// </summary>
        public Thickness? Thickness { get; set; }

        /// <summary>
        /// 用途
        /// </summary>
        public GlassUsage? GlassUsage { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCodeNo { get; set; }

        /// <summary>
        /// 登记日期
        /// </summary>
        public Range<DateTime?> CreateTime { get; set; }
    }
}
