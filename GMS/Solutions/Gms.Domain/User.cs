using System;
using Gms.Common;

namespace Gms.Domain
{
    using SharpArch.Domain.DomainModel;

    public class User : Entity
    {
        /// <summary>
        /// 用户验证用的Id
        /// </summary>
        public virtual Guid MemberShipId { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public virtual string LoginName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public virtual string RealName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public virtual string NickName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public virtual Gender Gender { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public virtual string Mobile { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public virtual string Note { get; set; }
    }


    public class UserQuery:QueryBase
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender? Gender { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Note { get; set; }
        
    }

}