using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    public class Customer : LinkMan
    {
        public Customer()
        {
            LinkmanType = LinkmanType.客户;
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
        /// 累计积分
        /// </summary>
        public virtual int Point { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public virtual String Address { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }
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
