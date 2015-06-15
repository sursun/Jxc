using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using Gms.Common;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 加工处理
    /// </summary>
    public class ProductCure:Entity
    {
        public ProductCure()
        {
            this.StartTime = DateTime.Now;
            this.EndTime = DateTime.Now;
        }
        /// <summary>
        /// 所属订单
        /// </summary>
        [ScriptIgnore]
        public virtual Order Order { get; set; }

        /// <summary>
        /// 加工类型
        /// </summary>
        public virtual CommonCode CureType { get; set; }

        /// <summary>
        /// 加工人员
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// 质检员（车间主任）
        /// </summary>
        public virtual User CheckUser { get; set; }

        /// <summary>
        /// 开始加工时间（领单日期）
        /// </summary>
        public virtual DateTime StartTime { get; set; }

        /// <summary>
        /// 结束加工时间（交单日期）
        /// </summary>
        public virtual DateTime EndTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }
    }

    public class ProductCureQuery : QueryBase
    {
        /// <summary>
        /// 所属订单
        /// </summary>
        public int? OrderId { get; set; }

        /// <summary>
        /// 加工类型
        /// </summary>
        public int? CureTypeId { get; set; }

        /// <summary>
        /// 加工人员
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// 质检员（车间主任）
        /// </summary>
        public String CheckUserName { get; set; }

        /// <summary>
        /// 开始加工时间（领单日期）
        /// </summary>
        public Range<DateTime?> StartTime { get; set; }

        /// <summary>
        /// 结束加工时间（交单日期）
        /// </summary>
        public Range<DateTime?> EndTime { get; set; }


    }
}
