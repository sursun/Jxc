using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;
using Gms.Domain.Attribute;

namespace Gms.Infrastructure.NHibernateMaps.Conventions
{
    public class PropertyConvention : IPropertyConvention
    {
        #region IConvention<IPropertyInspector,IPropertyInstance> 成员
        static readonly Type tp = typeof(FluentNHibernate.Mapping.GenericEnumMapper<>);
        public void Apply(FluentNHibernate.Conventions.Instances.IPropertyInstance instance)
        {
            // instance.CustomType

            if (instance.Type.IsGenericType && instance.Type.GetGenericTypeDefinition() == tp)
            {
                var realType = instance.Type.GenericArguments.First();
                if (realType.IsEnum)
                {
                    instance.CustomType(realType);
                }

            }

            var list = instance.Property.MemberInfo.GetCustomAttributes(typeof(FieldLengthAttribute), true);
            if (list.Length > 0)
            {
                instance.Length(((FieldLengthAttribute)list[0]).Length);
            }

        }

        #endregion
    }
}
