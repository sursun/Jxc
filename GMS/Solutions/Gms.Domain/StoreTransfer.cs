using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 商品调拨
    /// </summary>
    public class StoreTransfer : AuditBase
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
        /// 
        public virtual CommonCode ToStore { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }
        
    }

    public class StoreTransferQuery : AuditBaseQuery
    {
        /// <summary>
        /// 票号
        /// </summary>
        public String CodeNo { get; set; }

        /// <summary>
        /// 单据编号
        /// </summary>
        public String OrderCode { get; set; }

        /// <summary>
        /// 单据日期
        /// </summary>
        public Range<DateTime?>  OrderTime { get; set; }

        /// <summary>
        /// 调出仓库
        /// </summary>
        public int? FromStoreId { get; set; }

        /// <summary>
        /// 调入仓库
        /// </summary>
        public int? ToStoreId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }

    }
}
