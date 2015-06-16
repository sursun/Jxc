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
    /// <summary>
    /// 设备
    /// </summary>
    public class Goods : Entity
    {
        /// <summary>
        /// 类别
        /// </summary>
        public virtual CommonCode EquiType { get; set; }
        
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// 型号
        /// </summary>
        public virtual string Model { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public virtual string Unit { get; set; }
        
        /// <summary>
        /// 数量
        /// </summary>
        public virtual int Quantity { get; set; }

        /// <summary>
        /// 最低数量
        /// </summary>
        public virtual int MinQuantity { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public virtual decimal Price { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Note { get; set; }
    }

    public class EquipmentQuery : QueryBase
    {
        /// <summary>
        /// 类别
        /// </summary>
        public int? EquiType { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public Range<int?> Quantity { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public Range<decimal?> Price { get; set; }

        /// <summary>
        /// 预警
        /// </summary>
        public bool? IsWarning { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

    }
}
