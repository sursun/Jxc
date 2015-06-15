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
    /// 出库物料
    /// </summary>
    public class EquiOut : Entity
    {
        /// <summary>
        /// 出库单
        /// </summary>
        public virtual EquiStoreOut EquiStoreOut { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        public virtual Equipment Equipment { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public virtual int Quantity { get; set; }

        /// <summary>
        /// 出库价格
        /// </summary>
        public virtual decimal Price { get; set; }
    }

    public class EquiOutQuery : QueryBase
    {
        /// <summary>
        /// 出库单
        /// </summary>
        public int? EquiStoreOutId { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        public int? EquipmentId { get; set; }

        /// <summary>
        /// 物料 名称
        /// </summary>
        public string EquipmentName { get; set; }

        /// <summary>
        /// 出库价格
        /// </summary>
        public Range<decimal?> Price { get; set; }
    }

}
