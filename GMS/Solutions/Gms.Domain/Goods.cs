using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Gms.Common;
using Gms.Domain.Attribute;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 商品
    /// </summary>
    public class Goods : Entity
    {
        /// <summary>
        /// 编码
        /// </summary>
        public virtual String CodeNo { get; set; }

        /// <summary>
        /// 条码
        /// </summary>
        public virtual String BarCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// 商品缩略图
        /// </summary>
        public virtual String Picture { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
        public virtual String Model { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public virtual CommonCode Unit { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public virtual decimal Quantity { get; set; }

        /// <summary>
        /// 最低数量
        /// </summary>
        public virtual decimal MinQuantity { get; set; }

        /// <summary>
        /// 最高数量
        /// </summary>
        public virtual decimal MaxQuantity { get; set; }

        /// <summary>
        /// 低值预警
        /// </summary>
        [NotMap]
        public virtual Boolean IsMinWarning {
            get { return Quantity <= MinQuantity; }
        }

        /// <summary>
        /// 高值预警
        /// </summary>
        [NotMap]
        public virtual Boolean IsMaxWarning {
            get { return Quantity >= MaxQuantity; }
        }

        /// <summary>
        /// 商品品牌
        /// </summary>
        public virtual CommonCode Brand { get; set; }

        /// <summary>
        /// 陈列架
        /// </summary>
        public virtual CommonCode DisplayStands { get; set; }

        /// <summary>
        /// 进价
        /// 采购价
        /// </summary>
        public virtual decimal PurchasePrice { get; set; }

        /// <summary>
        /// 零售价
        /// </summary>
        public virtual decimal RetailPrice { get; set; }

        /// <summary>
        /// 最低限价
        /// </summary>
        public virtual decimal MinPrice { get; set; }

        /// <summary>
        /// 是否特价
        /// </summary>
        public virtual Boolean IsBargin { get; set; }

        /// <summary>
        /// 特价
        /// </summary>
        public virtual decimal BarginPrice { get; set; }
         
        /// <summary>
        /// 是否允许前台改价销售
        /// </summary>
        public virtual Boolean IsFreePrice { get; set; }

        /// <summary>
        /// 积分金额
        /// 消费多少元获得1积分，0代表按系统设置统一积分
        /// </summary>
        public virtual decimal PointBase { get; set; }

        /// <summary>
        /// 商品状态
        /// </summary>
        public virtual GoodsStatus GoodsStatus { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
     
        
    }

    public class GoodsQuery : QueryBase
    {
        /// <summary>
        /// 编码
        /// </summary>
        public String CodeNo { get; set; }

        /// <summary>
        /// 条码
        /// </summary>
        public String BarCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public String Name { get; set; }
        
        /// <summary>
        /// 数量
        /// </summary>
        public Range<int?> Quantity { get; set; }

        /// <summary>
        /// 低值预警
        /// </summary>
        public Boolean? IsMinWarning { get; set; }

        /// <summary>
        /// 高值预警
        /// </summary>
        public Boolean? IsMaxWarning { get; set; }
   
        /// <summary>
        /// 商品品牌
        /// </summary>
        public int? BrandId { get; set; }

        /// <summary>
        /// 陈列架
        /// </summary>
        public int? DisplayStandsId { get; set; }

        /// <summary>
        /// 是否特价
        /// </summary>
        public Boolean? IsBargin { get; set; }
        
        /// <summary>
        /// 是否允许前台改价销售
        /// </summary>
        public Boolean? IsFreePrice { get; set; }

        /// <summary>
        /// 积分金额
        /// 消费多少元获得1积分，0代表按系统设置统一积分
        /// </summary>
        public Range<decimal?> PointBase { get; set; }

        /// <summary>
        /// 商品状态
        /// </summary>
        public GoodsStatus? GoodsStatus { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public Range<DateTime?>  CreateTime { get; set; }

    }
}
