using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.ExtensionMethods
{
    public static class NullableTypes
    {
        public static bool TryParseBool(this bool? value)
        {
            if (value == null)
                return false;

            return (bool)value;
        }

        public static DateTime TryParseDateTime(this DateTime? value)
        {
            return value ?? DateTime.MinValue;
        }

        public static int TryParseInt(this int? value)
        {
            return value ?? Int32.MinValue;
        }

        public static int? TryParseInt(this string val)
        {
            int outValue;
            return int.TryParse(val, out outValue) ? (int?)outValue : null;
        }
    }
}
