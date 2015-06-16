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
    /// 单位信息
    /// </summary>
    public class Company:Entity
    {
        /// <summary>
        /// 单位编号
        /// </summary>
        public virtual String CodeNo { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public virtual String Fax { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public virtual String Telephone { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public virtual String PostCode { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public virtual String Address { get; set; }

        /// <summary>
        /// 注册信息
        /// </summary>
        [FieldLength(4000)]
        public virtual String RegKey { get; set; }
        
        #region 记录最新编码
        
        /// <summary>
        /// 最新客户编码
        /// </summary>
        public virtual String LastCustomerCode { get; set; }

        /// <summary>
        /// 最新供应商编码
        /// </summary>
        public virtual String LastSupplierCode { get; set; }
        
        #endregion

        #region 配置审核

        /// <summary>
        /// 是否审核 采购单
        /// </summary>
        public virtual Boolean Caigou { get; set; }

        /// <summary>
        /// 是否审核 采购退货单
        /// </summary>
        public virtual Boolean CaigouTh { get; set; }

        /// <summary>
        /// 是否审核 销售单
        /// </summary>
        public virtual Boolean Xiaoshou { get; set; }

        /// <summary>
        /// 是否审核 销售退货单
        /// </summary>
        public virtual Boolean XiaoshouTh { get; set; }

        /// <summary>
        /// 是否审核 流转记账
        /// </summary>
        public virtual Boolean JizhangLiu { get; set; }

        /// <summary>
        /// 是否审核 收入记账
        /// </summary>
        public virtual Boolean JizhangShou { get; set; }

        /// <summary>
        /// 是否审核 支出记账
        /// </summary>
        public virtual Boolean JizhangZhi { get; set; }

        /// <summary>
        /// 是否审核 商品入库
        /// </summary>
        public virtual Boolean Ruku { get; set; }

        /// <summary>
        /// 是否审核 商品出库
        /// </summary>
        public virtual Boolean Chuku { get; set; }

        /// <summary>
        /// 是否审核 商品调价
        /// </summary>
        public virtual Boolean Tiaojia { get; set; }

        #endregion

        /// <summary>
        /// 单价小数位
        /// 精确度
        /// </summary>
        public virtual int PriceAccuracy { get; set; }

        /// <summary>
        /// 数量小数位
        /// 精确度
        /// </summary>
        public virtual int AmountAccuracy { get; set; }

        /// <summary>
        /// 库存计价法
        /// </summary>
        public virtual InventoryPricing InventoryPricing { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }
  
}
