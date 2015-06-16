using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 供应商
    /// </summary>
    public class Supplier : RelationPerson
    {
        public Supplier()
        {
            RelationType = RelationType.供应商;
        }

        /// <summary>
        /// 供应商类别
        /// </summary>
        public virtual CommonCode SupplierType { get; set; }

        /// <summary>
        /// 税号
        /// </summary>
        public virtual String ShuiHao { get; set; }

        /// <summary>
        /// 帐号
        /// </summary>
        public virtual String CardNo { get; set; }

        /// <summary>
        /// 增值税率
        /// </summary>
        public virtual decimal TaxRate { get; set; }

        /// <summary>
        /// 期初应付款
        /// </summary>
        public virtual Decimal FukuanQc { get; set; }

        /// <summary>
        /// 应付款
        /// </summary>
        public virtual Decimal FukuanYing { get; set; }

        /// <summary>
        /// 预付款
        /// </summary>
        public virtual Decimal FukuanYu { get; set; }
    }
}
