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

    public enum CommonCodeType
    {
        加工类型,
        玻璃品种,
        物料类型,
        物料来源,
        物料用途
    }

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

