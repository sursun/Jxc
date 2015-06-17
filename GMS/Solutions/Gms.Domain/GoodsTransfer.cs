using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 商品调拨
    /// </summary>
    public class GoodsTransfer : Entity
    {
        /// <summary>
        /// 票号
        /// </summary>
        public virtual String CodeNo { get; set; }

        /// <summary>
        /// 单据编号
        /// </summary>
        public virtual String OrderCode { get; set; }

        /// <summary>
        /// 单据日期
        /// </summary>
        public virtual DateTime OrderTime { get; set; }
        
        /// <summary>
        /// 调出仓库
        /// </summary>
        public virtual CommonCode FromStore { get; set; }

        /// <summary>
        /// 调入仓库
        /// </summary>
        public virtual CommonCode ToStore { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public virtual User Auditor { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public virtual DateTime AuditTime { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public virtual AuditState AuditState { get; set; }

        /// <summary>
        /// 审核说明
        /// </summary>
        public virtual String AuditNote { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }

        /// <summary>
        /// 登记人
        /// </summary>
        public virtual User Creator { get; set; }

        /// <summary>
        /// 登记日期
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }
}
