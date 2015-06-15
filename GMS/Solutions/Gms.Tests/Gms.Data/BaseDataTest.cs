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



  
    }
}
