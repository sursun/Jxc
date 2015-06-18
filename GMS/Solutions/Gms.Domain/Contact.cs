using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 联系方式
    /// </summary>
    public class Contact:Entity
    {
        /// <summary>
        /// 所属联系人
        /// </summary>
        public virtual RelationPerson RelationPerson { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public virtual Gender Gender { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public virtual String CardNo { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public virtual DateTime Birthday { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public virtual String Mobile { get; set; }

        /// <summary>
        /// QQ号码
        /// </summary>
        public virtual String QQ { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public virtual String Email { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public virtual String Address { get; set; }

        /// <summary>
        /// 是否为默认联系方式？
        /// </summary>
        public virtual Yesno IsDefault { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }

    public class ContactQuery : QueryBase
    {
        /// <summary>
        /// 所属联系人
        /// </summary>
        public int? RelationPersonId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender? Gender { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public String CardNo { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public String Mobile { get; set; }
        
        /// <summary>
        /// 是否为默认联系方式？
        /// </summary>
        public Yesno? IsDefault { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public Range<DateTime?> CreateTime { get; set; }
    }
}
