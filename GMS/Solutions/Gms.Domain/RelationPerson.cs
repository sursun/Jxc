using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Common;
using SharpArch.Domain.DomainModel;

namespace Gms.Domain
{
    /// <summary>
    /// 联系人
    /// 客户|供应商
    /// </summary>
    public class RelationPerson : Entity
    {
        /// <summary>
        /// 联系人类型
        /// </summary>
        public virtual RelationType RelationType { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public virtual String CodeNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// 拼音（姓名）
        /// </summary>
        public virtual String Pinyin { get; set; }

        /// <summary>
        /// 默认结算账户
        /// </summary>
        public virtual Account Account { get; set; }

        /// <summary>
        /// 期初日期
        /// </summary>
        public virtual DateTime BaseTime { get; set; }

        /// <summary>
        /// 累计金额
        /// 消费（客户）
        /// 采购（供应商）
        /// </summary>
        public virtual decimal Amount { get; set; }

        /// <summary>
        /// 添加日期（开户时间）
        /// </summary>
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual String Note { get; set; }
    }

    public class RelationPersonQuery : QueryBase
    {
        /// <summary>
        /// 联系人类型
        /// </summary>
        public RelationType? RelationType { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public String CodeNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public String Name { get; set; }
         
        /// <summary>
        /// 拼音（姓名）
        /// </summary>
        public String Pinyin { get; set; }

        /// <summary>
        /// 添加日期（开户时间）
        /// </summary>
        public Range<DateTime?>  CreateTime { get; set; }

    }
}
