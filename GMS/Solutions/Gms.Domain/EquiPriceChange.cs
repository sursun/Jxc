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
    /// 物料价格变化
    /// </summary>
    public class EquiPriceChange : Entity
    {
        /// <summary>
        /// 入库物料
        /// </summary>
        public virtual EquiIn EquiIn { get; set; }

        /// <summary>
        /// 原库存量
        /// </summary>
        public virtual int Quantity { get; set; }

        /// <summary>
        /// 原价格
        /// </summary>
        public virtual decimal OldPrice { get; set; }

        /// <summary>
        /// 新价格
        /// </summary>
        public virtual decimal NewPrice { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// 价格变动时间
        /// </summary>
        public virtual DateTime CreateDateTime { get; set; }
    }

    public class EquiPriceChangeQuery : QueryBase
    {
        /// <summary>
        /// 入库物料 名称
        /// </summary>
        public string EquiName { get; set; }
        
        /// <summary>
        /// 价格变动时间
        /// </summary>
        public Range<DateTime?> CreateDateTime { get; set; }
    }
}
