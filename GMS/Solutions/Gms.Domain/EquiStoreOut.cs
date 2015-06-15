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
    /// 出库单
    /// </summary>
    public class EquiStoreOut : Entity
    {
        /// <summary>
        /// 出库单号
        /// </summary>
        public virtual string CodeNo { get; set; }
        
        /// <summary>
        /// 用途
        /// 销售
        /// 加工
        /// 损坏
        /// 赠送
        /// </summary>
        public virtual CommonCode EquiTo { get; set; }

        /// <summary>
        /// 总价格
        /// </summary>
        public virtual decimal Price { get; set; }

        /// <summary>
        /// 出库人
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// 出库时间
        /// </summary>
        public virtual DateTime CreateDateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Note { get; set; }
    }

    public class EquiStoreOutQuery : QueryBase
    {
        /// <summary>
        /// 出库单号
        /// </summary>
        public string CodeNo { get; set; }
        
        /// <summary>
        /// 用途
        /// 销售
        /// 加工
        /// 损坏
        /// 赠送
        /// </summary>
        public int? EquiToId { get; set; }

        /// <summary>
        /// 总价格
        /// </summary>
        public Range<decimal?> Price { get; set; }

        /// <summary>
        /// 出库人 姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 出库时间
        /// </summary>
        public Range<DateTime?> CreateDateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
    }
  
}
