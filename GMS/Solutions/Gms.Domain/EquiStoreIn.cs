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
    /// 入库单
    /// </summary>
    public class EquiStoreIn : Entity
    {
        /// <summary>
        /// 入库单号
        /// </summary>
        public virtual string CodeNo { get; set; }

        /// <summary>
        /// 来源
        /// 购买
        /// 赠送
        /// </summary>
        public virtual CommonCode EquiFrom { get; set; }

        /// <summary>
        /// 总价格
        /// </summary>
        public virtual decimal Price { get; set; }

        /// <summary>
        /// 入库人
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// 入库时间
        /// </summary>
        public virtual DateTime CreateDateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Note { get; set; }
    }

    public class EquiStoreInQuery : QueryBase
    {
        /// <summary>
        /// 入库单号
        /// </summary>
        public string CodeNo { get; set; }

        /// <summary>
        /// 来源
        /// 购买
        /// 赠送
        /// </summary>
        public int? EquiFromId { get; set; }

        /// <summary>
        /// 总价格
        /// </summary>
        public Range<decimal?> Price { get; set; }

        /// <summary>
        /// 入库人 名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 入库时间
        /// </summary>
        public Range<DateTime?> CreateDateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
    }
  
  
}
