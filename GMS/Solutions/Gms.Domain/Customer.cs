using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    public class Customer:Entity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public virtual String Mobile { get; set; }
        
        /// <summary>
        /// 公司
        /// </summary>
        public virtual String Company { get; set; }

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
