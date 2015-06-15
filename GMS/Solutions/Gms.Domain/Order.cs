using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Gms.Common;
using Newtonsoft.Json;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    public class Order:Entity
    {
        public Order()
        {
            this.CreateTime = DateTime.Now;
            this.ModifyTime = DateTime.Now;
            this.DeliveryDate = DateTime.Now;
        }

        /// <summary>
        /// 订单编号
        /// </summary>
        public virtual String CodeNo { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 加工过程
        /// </summary>
        public virtual CureProcess CureProcess { get; set; }

        /// <summary>
        /// 加工处理
        /// </summary>
        public virtual IList<ProductCure> Cures { get; set; }

        /// <summary>
        /// 产品列表
        /// </summary>
        public virtual IList<Product> Products { get; set; }

        /// <summary>
        /// 附件列表
        /// </summary>
        public virtual String Addtions { get; set; }

        /// <summary>
        /// 录单员
        /// </summary>
        public virtual User CreateUser { get; set; }

        /// <summary>
        /// 复核员
        /// </summary>
        public virtual User CheckUser { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public virtual OrderState OrderState { get; set; }

        /// <summary>
        /// 交货日期
        /// </summary>
        public virtual DateTime DeliveryDate { get; set; }

        /// <summary>
        /// 总价（计算值）
        /// </summary>
        public virtual decimal TotalPrice { get; set; }

        /// <summary>
        /// 总价（实收金额）
        /// </summary>
        public virtual decimal RealTotalPrice { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public virtual DateTime ModifyTime { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }

    public class OrderQuery : QueryBase
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string CodeNo { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 客户手机号
        /// </summary>
        public string CustomerMobile { get; set; }

        /// <summary>
        /// 总价（计算值）
        /// </summary>
        public Range<decimal?> TotalPrice { get; set; }

        /// <summary>
        /// 总价（实收金额）
        /// </summary>
        public Range<decimal?> RealTotalPrice { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public Range<DateTime?> ModifyTime { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public Range<DateTime?> CreateTime { get; set; }

    }
}
