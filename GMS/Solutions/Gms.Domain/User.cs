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
        /// 登录名（编号）
        /// </summary>
        public virtual String LoginName { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public virtual Department Department { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        public virtual String Duty { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public virtual String RealName { get; set; }

        /// <summary>
        /// 简拼
        /// 真实姓名
        /// </summary>
        public virtual String Pinyin { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public virtual String NickName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public virtual Gender Gender { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public virtual String IdCard { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public virtual DateTime Birthday { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        public virtual CommonCode Nation { get; set; }

        /// <summary>
        /// 教育水平
        /// </summary>
        public virtual CommonCode Diploma { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        public virtual DateTime EntryDate { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public virtual String Mobile { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public virtual String Address { get; set; }

        #region 权限

        /// <summary>
        /// 员工类别
        /// </summary>
        public virtual int EmployeeType { get; set; }

        /// <summary>
        /// 菜单权限
        /// </summary>
        public virtual String MenuRight { get; set; }

        /// <summary>
        /// 业务权限
        /// </summary>
        public virtual String BusinessRight { get; set; }

        #endregion

        /// <summary>
        /// 状态
        /// </summary>
        public virtual EmployeeStatus EmployeeStatus { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
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