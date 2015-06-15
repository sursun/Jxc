using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gms.Common
{
    public static class StringExtensions
    {
        public static bool NotNullAndEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static bool IsNull(this string str)
        {
            return str == null;
        }

        public static bool IsEmpty(this string str)
        {
            return str == string.Empty;
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

    }
}
