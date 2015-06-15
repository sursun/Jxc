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
    /// 入库物料
    /// </summary>
    public class EquiIn : Entity
    {
        /// <summary>
        /// 入库单
        /// </summary>
        public virtual EquiStoreIn EquiStoreIn { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        public virtual Equipment Equipment { get; set; }

        /// <summary>
        /// 原库存量
        /// </summary>
        public virtual int OldQuantity { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public virtual int Quantity { get; set; }

        /// <summary>
        /// 入库价格
        /// </summary>
        public virtual decimal Price { get; set; }
    }

    public class EquiInQuery : QueryBase
    {
        /// <summary>
        /// 入库单
        /// </summary>
        public int? EquiStoreInId { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        public int? EquipmentId { get; set; }

        /// <summary>
        /// 物料 名称
        /// </summary>
        public string EquipmentName { get; set; }

        /// <summary>
        /// 入库价格
        /// </summary>
        public Range<decimal?> Price { get; set; }
    }
}
