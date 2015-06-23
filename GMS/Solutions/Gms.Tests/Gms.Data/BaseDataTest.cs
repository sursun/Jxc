using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Security;
using Gms.Domain;
using Gms.Infrastructure;
using Gms.Infrastructure.NHibernateMaps;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using SharpArch.NHibernate;
using SharpArch.Testing.NUnit.NHibernate;

namespace Gms.Tests.Gms.Data
{

   [TestFixture]
    [Category("DB Tests")]
    public class BaseDataTest
    {
        private Configuration configuration;

        [SetUp]
        public virtual void SetUp()
        {
            string[] mappingAssemblies = RepositoryTestsHelper.GetMappingAssemblies();
            this.configuration = NHibernateSession.Init(
                new SimpleSessionStorage(),
                mappingAssemblies,
                new AutoPersistenceModelGenerator().Generate(),
                "../../../../Solutions/Gms.Web.Mvc/NHibernate.config");

            IDbConnection connection = NHibernateSession.Current.Connection;
            new SchemaExport(configuration).Execute(false, true, false, connection, null);
        }

        [TearDown]
        public virtual void TearDown()
        {
            NHibernateSession.CloseAllSessions();
            NHibernateSession.Reset();
        }

       public IUserRepository userRepository = new UserRepository();
        [Test]
        public void CreateUser()
        {
            

            for (int i = 0; i < 100; i++)
            {
                User user = new User();
                user.Note = "测试数据";
                user.RealName = String.Format("测试用户{0}", i);
                user.NickName = user.RealName;
                user.Gender = Gender.男; 

               // MembershipUser membershipuser = Membership.CreateUser(String.Format("test{0}",i), "123456");
               //user.MemberShipId = (Guid) membershipuser.ProviderUserKey;
                user.MemberShipId = Guid.NewGuid();

                userRepository.SaveOrUpdate(user);
            }

            NHibernateSession.Current.Flush();


        }

        [Test]
        public void InitData()
        {
            var depart = CreateDepartment();

            //CreateDoctor(depart);

            //CreatePatient();

            InitCommonCode();

            NHibernateSession.Current.Flush();
        }


        public void InitCommonCode()
        {
            ICommonCodeRepository commonCodeRepository = new CommonCodeRepository();

            //地区
            //commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.地区, Name = "北京"});
            //commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.地区, Name = "天津" });
            //commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.地区, Name = "上海" });
            //commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.地区, Name = "重庆" });
            //var parent = commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.地区, Name = "山东" });
            //commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.地区,Parent = parent,Name = "济南" });
            //commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.地区, Parent = parent,Name = "青岛" });
            //commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.地区, Parent = parent,Name = "淄博" });
            //commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.地区, Parent = parent,Name = "枣庄" });
            //commonCodeRepository.SaveOrUpdate(new CommonCode() {Type = CommonCodeType.地区, Parent = parent, Name = "泰安"});

            //民族
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "汉族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "壮族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "满族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "回族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "苗族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "维吾尔族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "土家族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "彝族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "蒙古族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "藏族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "布依族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "侗族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "瑶族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "朝鲜族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "白族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "哈尼族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "哈萨克族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "黎族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "傣族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "畲族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "傈僳族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "仡佬族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "东乡族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "高山族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "拉祜族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "水族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "佤族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "纳西族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "羌族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "土族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "仫佬族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "锡伯族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "柯尔克孜族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "达斡尔族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "景颇族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "毛南族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "撒拉族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "布朗族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "塔吉克族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "阿昌族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "普米族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "鄂温克族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "怒族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "京族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "基诺族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "德昂族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "保安族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "俄罗斯族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "裕固族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "乌孜别克族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "门巴族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "鄂伦春族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "独龙族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "塔塔尔族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "赫哲族" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.民族, Name = "珞巴族" });

            //教育水平
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.教育水平, Name = "小学及以下" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.教育水平, Name = "初中" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.教育水平, Name = "高中" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.教育水平, Name = "中专" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.教育水平, Name = "大专" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.教育水平, Name = "本科" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.教育水平, Name = "硕士" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.教育水平, Name = "博士及以上" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.教育水平, Name = "博士后" });

            //客户类别
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.客户类别, Name = "1型糖尿病" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.客户类别, Name = "2型糖尿病" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.客户类别, Name = "正常耐糖量" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.客户类别, Name = "妊娠糖尿病" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.客户类别, Name = "特殊类型糖尿病" });

            //客户等级
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.客户等级, Name = "在校学生" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.客户等级, Name = "计算机/网络/IT技术" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.客户等级, Name = "经营管理" });
            commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.客户等级, Name = "娱乐业" });

        //,
        //供应商类别,
        //商品类别,
        //商品品牌,
        //商品陈列,
        //仓库,
        //入库业务类型,//采购入库、其他入库
        //出库业务类型,
        //收入记账类型,
        //支出记账类型,
        //计量单位

            //药品类别
            //commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.药品类别, Name = "降压药" });
            //commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.药品类别, Name = "降糖药" });
            //commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.药品类别, Name = "降脂药" });
            //commonCodeRepository.SaveOrUpdate(new CommonCode() { Type = CommonCodeType.药品类别, Name = "其他" });

        }

        [Test]
        public Department CreateDepartment()
        {
            IDepartmentRepository departmentRepository = new DepartmentRepository();
            var deppart = departmentRepository.SaveOrUpdate(new Department()
            {
                Name = "采购部"
            });

            departmentRepository.SaveOrUpdate(new Department()
            {
                Parent = deppart,
                Name = "客服部"
            });

            return departmentRepository.SaveOrUpdate(new Department()
            {
                Parent = deppart,
                Name = "销售部"
            });
        }


  
    }
}
