using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Reflection;

namespace PXELDAR
{
    public class ValueAttribute : Attribute
    {
        public string Value;

        public ValueAttribute(string value)
        {
            Value = value;
        }
    }

    public static class EnumExtensions
    {
        //===================================================================================

        private static readonly Dictionary<Type, Dictionary<string, object>> _typeMap = new Dictionary<Type, Dictionary<string, object>>();

        //===================================================================================

        public static string String(this Enum value)
        {
            string attributeValue = GetAttributeValue(value);

            return attributeValue ?? value.ToString();
        }

        //===================================================================================

        public static string Value(this Enum value)
        {
            return GetAttributeValue(value);
        }

        //===================================================================================

        private static string GetAttributeValue(Enum value)
        {
            Contract.Requires(value != null);

            FieldInfo fi = value.GetType().GetTypeInfo().GetDeclaredField(value.ToString());

            if (fi != null)
            {
                ValueAttribute[] attributes = (ValueAttribute[])fi.GetCustomAttributes(typeof(ValueAttribute), false);

                if (attributes.Length > 0)
                {
                    return attributes[0].Value;
                }
            }

            return default;
        }

        //===================================================================================

        public static T ParseValuedEnum<T>(this string str, T defaultValue = default(T))
            where T : struct
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            if (str == null)
            {
                return defaultValue;
            }

            Dictionary<string, object> map;
            if (!_typeMap.TryGetValue(typeof(T), out map))
            {
                map = new Dictionary<string, object>();
                Array values = Enum.GetValues(typeof(T));
                foreach (var v in values)
                {
                    ValueAttribute attr = v.GetType().GetTypeInfo().GetDeclaredField(v.ToString()).GetCustomAttribute<ValueAttribute>();
                    if (attr == null)
                    {
                        throw new InvalidOperationException(string.Format("Enum {0} doesnt have Value attribute on one of it values", typeof(T).Name));
                    }

                    map[attr.Value] = v;
                }

                _typeMap[typeof(T)] = map;
            }

            object result;
            return map.TryGetValue(str, out result) ? (T)result : defaultValue;
        }

        //===================================================================================

    }
}