using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Gms.Common
{
    public static class ReflectionExtensions
    {
        public static Type GetRealType(this PropertyInfo pi)
        {
            if (pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                Type realType = Nullable.GetUnderlyingType(pi.PropertyType);
                return realType;
            }
            return pi.PropertyType;
        }

        public static Type GetRealType(this Type pi)
        {
            if (pi.IsGenericType && pi.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                Type realType = Nullable.GetUnderlyingType(pi);
                return realType;
            }
            return pi;
        }

        public static object SetValue(this Type tp, object item, string propertyname, string value)
        {
            var pi = tp.GetProperty(propertyname);
            if (pi == null || !pi.CanWrite) return false;
            ////如果忽略该属性则继续处理下一个
            //IgnoreAttribute[] customAttributes = (IgnoreAttribute[])pi.GetCustomAttributes(typeof(IgnoreAttribute), false);
            //if (customAttributes.Length > 0) return;

            object datavalue;
            //转换枚举类型
            if (pi.PropertyType.IsEnum)
            {
                try
                {
                    datavalue = Enum.Parse(pi.PropertyType, value);  //Enum.ToObject(pi.PropertyType, Convert.ToInt32(item.SettingValue));
                }
                catch
                {
                    try
                    {
                        datavalue = Enum.ToObject(pi.PropertyType, value);
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            else
            {
                //将数据转换为属性的类型
                datavalue = Convert.ChangeType(value, pi.GetRealType());
            }
            pi.SetValue(item, datavalue, null);
            return datavalue;
        }

    }
}
