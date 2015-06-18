using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    public class AuditBase:Entity
    {
        /// <summary>
        /// 登记人
        /// </summary>
        public virtual User Creator { get; set; }

        /// <summary>
        /// 登记日期
        /// </summary>
        public virtual DateTime CreateTime { get; set; }

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

    }

    public class AuditBaseQuery : QueryBase
    {
        /// <summary>
        /// 登记人
        /// Id
        /// </summary>
        public int? CreatorId { get; set; }

        /// <summary>
        /// 登记人
        /// 姓名
        /// </summary>
        public String CreatorName { get; set; }

        /// <summary>
        /// 登记日期
        /// </summary>
        public Range<DateTime?> CreateTime { get; set; }

        /// <summary>
        /// 审核人
        /// Id
        /// </summary>
        public int? AuditorId { get; set; }

        /// <summary>
        /// 审核人
        /// 姓名
        /// </summary>
        public String AuditorName { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public Range<DateTime?> AuditTime { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public AuditState? AuditState { get; set; }

        /// <summary>
        /// 审核说明
        /// </summary>
        public String AuditNote { get; set; }
    }
}
