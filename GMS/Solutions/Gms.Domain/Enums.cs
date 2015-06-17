using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gms.Domain
{
    public enum Gender
    {
        男,
        女
    }

    public enum Yesno
    {
        是,
        否
    }

    public enum EmployeeType
    {
        采购员 = 0x00000001,
        业务员 = 0x00000002,
        库管员 = 0x00000004
    }

    public enum EmployeeStatus
    {
        在职,锁定,离职
    }

    /// <summary>
    /// 商品状态
    /// 进销---正常状态
    /// 停用---无法销售进货 
    /// 只销---只销售不进货、
    /// 停销---只进货不销售
    /// </summary>
    public enum GoodsStatus
    {
        进销, 停用, 只销, 停销
    }

    public enum RelationType
    {
        客户,供应商
    }

    public enum CommonCodeType
    {
        民族,
        教育水平,
        客户类别,
        供应商类别,
        商品类别,
        商品品牌,
        商品陈列,
        仓库,
        入库业务类型,//采购入库、其他入库
        出库业务类型,
        收入记账类型,
        支出记账类型,
        计量单位
    }

    /// <summary>
    /// 库存计价法
    /// </summary>
    public enum InventoryPricing
    {
        先进先出法,加权平均法,移动平均法,个别计价法,后进先出法
    }

    /// <summary>
    /// 价格类型
    /// </summary>
    public enum PriceType
    {
        进价,批发价,零售价,会员价
    }

    public enum AuditState
    {
        未审核,正在审核,审核失败,审核成功
    }

    //----------------------------------------------------//

    
    public enum OrderState
    {
        未处理,
        加工中,
        加工完成,
        发货中,
        完成
    }

    public enum Sharp
    {
        平行四边形,
        矩形,
        圆形,
        椭圆形
    }

    public enum CureState
    {
        未加工,
        加工中,
        加工完成
    }

    /// <summary>
    /// 磨边类型
    /// </summary>
    public enum EdgingType
    {
        直边,斜边,圆边,倒圆边,车边
    }

    /// <summary>
    /// 玻璃厚度
    /// </summary>
    public enum Thickness
    {
        _3mm, _4mm, _5mm, _6mm, _8mm, _10mm, _12mm, _15mm, _19mm
    }

    public enum GlassUsage
    {
        入库,
        加工,
        损坏,
        其他
    }
    
    public enum AuthType
    {
        角色管理,
        用户管理,
        客户管理,
        订单管理,
        日志管理
    }

    public enum ActionPoint
    {
        添加 = 0x00000001,
        删除 = 0x00000002,
        修改 = 0x00000004,
        导入 = 0x00000008,
        导出 = 0x00000010
    }

}

