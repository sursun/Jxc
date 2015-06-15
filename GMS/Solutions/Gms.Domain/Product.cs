using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Gms.Common;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    public class Product:Entity
    {
        /// <summary>
        /// 所属订单
        /// </summary>
        [ScriptIgnore]
        public virtual Order Order { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 玻璃品种
        /// </summary>
        public virtual CommonCode GlassType { get; set; }

        /// <summary>
        /// 玻璃厚度
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
        /// 边长
        /// </summary>
        public virtual int EdgeLength { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
        public virtual int Area { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public virtual int Amount { get; set; }

        /// <summary>
        /// 小计（计算值）
        /// </summary>
        public virtual decimal Price { get; set; }

        /// <summary>
        /// 加工说明
        /// </summary>
        public virtual string Note { get; set; }
    }

    public class ProductQuery : QueryBase
    {
        public int? OrderId { get; set; }
        public string Name { get; set; }
        public int? GlassType { get; set; }
        public Thickness? Thickness { get; set; }

    }
}
