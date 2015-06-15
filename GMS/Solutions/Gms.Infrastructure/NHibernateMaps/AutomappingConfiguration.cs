using Gms.Domain.Attribute;

namespace Gms.Infrastructure.NHibernateMaps
{
    using System.Linq;
    using FluentNHibernate;
    using FluentNHibernate.Automapping;
    using SharpArch.Domain.DomainModel;

    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override string GetComponentColumnPrefix(Member member)
        {
            return member.Name + "_";
        }

        public override bool ShouldMap(System.Type type)
        {
            return type.GetInterfaces().Any(x =>
                 x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEntityWithTypedId<>));
        }

        public override bool ShouldMap(Member member)
        {

            if (member.IsProperty)
            {
                if (member.MemberInfo.GetCustomAttributes(typeof(NotMapAttribute), true).Length > 0)
                {
                    return false;
                }
            }

            return base.ShouldMap(member);
        }

        //public override bool AbstractClassIsLayerSupertype(System.Type type)
        //{
        //    return type == typeof(EntityWithTypedId<>) || type == typeof(Entity);
        //}

        public override bool IsId(Member member)
        {
            return member.Name == "Id";
        }
    }
}
