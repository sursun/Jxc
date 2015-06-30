using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    public class Customer : RelationPerson
    {
        public Customer()
        {
            RelationType = RelationType.客户;
        }

        /// <summary>
        /// 客户类型
        /// </summary>
        public virtual CommonCode CustomerType { get; set; }

        /// <summary>
        /// 客户等级 
        /// </summary>
        public virtual CommonCode CustomerGrade { get; set; }

        /// <summary>
        /// 期初应收款
        /// </summary>
        public virtual decimal ShoukuanQc { get; set; }

        /// <summary>
        /// 应收款
        /// </summary>
        public virtual decimal ShoukuanYing { get; set; }

        /// <summary>
        /// 预收款
        /// </summary>
        public virtual decimal ShoukuanYu { get; set; }

        /// <summary>
        /// 是否允许欠款
        /// </summary>
        public virtual Yesno AllowDebt { get; set; }

        /// <summary>
        /// 允许欠款金额
        /// </summary>
        public virtual decimal Debt { get; set; }
        
        /// <summary>
        /// 累计积分
        /// </summary>
        public virtual int Point { get; set; }

    }

    public class CustomerQuery : QueryBase
    {
        /// <summary>
        /// 客户类型
        /// </summary>
        public int? CustomerTypeId { get; set; }

        /// <summary>
        /// 客户等级 
        /// </summary>
        public int? CustomerGradeId { get; set; }

        /// <summary>
        /// 期初应收款
        /// </summary>
        public Range<decimal?> ShoukuanQc { get; set; }

        /// <summary>
        /// 应收款
        /// </summary>
        public Range<decimal?> ShoukuanYing { get; set; }

        /// <summary>
        /// 预收款
        /// </summary>
        public Range<decimal?> ShoukuanYu { get; set; }

        /// <summary>
        /// 是否允许欠款
        /// </summary>
        public Yesno? AllowDebt { get; set; }

        /// <summary>
        /// 允许欠款金额
        /// </summary>
        public Range<decimal?> Debt { get; set; }

        /// <summary>
        /// 累计积分
        /// </summary>
        public Range<int?> Point { get; set; }

    }
}
