using Gms.Common;
using Gms.Domain.Attribute;
using SharpArch.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gms.Domain
{
    /// <summary>
    /// 玻璃库存
    /// </summary>
    public class GlassStore:Entity
    {
        /// <summary>
        /// 玻璃品种
        /// </summary>
        public virtual CommonCode GlassType { get; set; }

        /// <summary>
        /// 厚度
        /// </summary>
        public virtual Thickness Thickness { get; set; }

        /// <summary>
        /// 长边
        /// </summary>
        public virtual int LongEdge { get; set; }

        /// <summary>
        /// 短边
        /// </summary>
        public virtual int ShortEdge { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public virtual int Amount { get; set; }

        /// <summary>
        /// 总面积
        /// </summary>
        public virtual int Area { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }
    }

    public class GlassStoreQuery : QueryBase
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
        /// 长边
        /// </summary>
        public int? LongEdge { get; set; }

        /// <summary>
        /// 短边
        /// </summary>
        public int? ShortEdge { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public Range<int?> Amount { get; set; }

    }
}
