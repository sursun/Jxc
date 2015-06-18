using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    public class Account : Entity
    {
        public Account()
        {
            CreateTime = DateTime.Now;
        }


        /// <summary>
        /// 编号
        /// </summary>
        public virtual String CodeNo { get; set; }

        /// <summary>
        /// 账户名称
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// 当前金额
        /// </summary>
        public virtual Decimal CurAmount { get; set; }

        /// <summary>
        /// 期初金额
        /// </summary>
        public virtual Decimal BaseAmount { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }

        /// <summary>
        /// 建账日期
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }
    
    public class AccountQuery : QueryBase
    {
        /// <summary>
        /// 编号
        /// </summary>
        public String CodeNo { get; set; }

        /// <summary>
        /// 账户名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 当前金额
        /// </summary>
        public Range<Decimal?> CurAmount { get; set; }

        /// <summary>
        /// 期初金额
        /// </summary>
        public Range<Decimal?> BaseAmount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }

        /// <summary>
        /// 建账日期
        /// </summary>
        public Range<DateTime?>  CreateTime { get; set; }
    }

}
