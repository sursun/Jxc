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
        public virtual CustomerGrade CustomerGrade { get; set; }

        /// <summary>
        /// 期初应收款
        /// </summary>
        public virtual Decimal ShoukuanQc { get; set; }

        /// <summary>
        /// 应收款
        /// </summary>
        public virtual Decimal ShoukuanYing { get; set; }

        /// <summary>
        /// 预收款
        /// </summary>
        public virtual Decimal ShoukuanYu { get; set; }

        /// <summary>
        /// 是否允许欠款
        /// </summary>
        public virtual Boolean AllowDebt { get; set; }

        /// <summary>
        /// 允许欠款金额
        /// </summary>
        public virtual Boolean Debt { get; set; }

        

        /// <summary>
        /// 累计积分
        /// </summary>
        public virtual int Point { get; set; }

    }

    public class CustomerQuery : QueryBase
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Company { get; set; }
        /// <summary>
        /// 在任意属性中查找
        /// </summary>
        public string AllInOne { get; set; }
    }
}
