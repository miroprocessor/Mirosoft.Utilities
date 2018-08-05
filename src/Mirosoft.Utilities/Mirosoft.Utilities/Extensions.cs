using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Mirosoft.Utilities
{
    public static class Extensions
    {
        public static string Description<T>(this T enumerationValue) where T : struct
        {
            var descAttribute = GetAttributeObject(enumerationValue, typeof(DescriptionAttribute));
            if (descAttribute != null)
            {
                return ((DescriptionAttribute)descAttribute).Description;
            }
            return string.Empty;
        }

        public static string Summary(this string input, int length)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            if (input.Length < length)
            {
                return input;
            }
            return input.Substring(0, length);
        }

        public static string ToLowerString(this object input)
        {
            if (input != null)
            {
                return input.ToString().ToLower();
            }
            return string.Empty;
        }

        public static IEnumerable<T> Deserialize<T>(this string jsons) where T : class
        {
            return JsonConvert.DeserializeObject<IEnumerable<T>>(jsons);
        }
        public static IEnumerable<T> Deserialize<T>(this string[] jsons) where T : class
        {
            foreach (var json in jsons)
            {
                yield return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public static string Serialize(this Object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string Format(this DateTime input, bool showTime = false)
        {
            if (showTime)
            {
                return $"{input:dd-MM-yyyy hh:mmtt}";
            }
            return $"{input:dd-MM-yyyy}";
        }

        public static string Format(this DateTime? input, bool showTime = false)
        {
            if (!input.HasValue)
            {
                return string.Empty;
            }

            return input.Value.Format(showTime);
        }

        public static string Format(this double input)
        {
            return $"{input:###,###,###,##0.00}";
        }

        public static string Format(this long input)
        {
            return $"{input:###,###,###,###}";
        }

        public static int PeriodInDays(this int totalDays)
        {
            var output = 0;
            output = totalDays / 365 * 365;
            totalDays %= 365;

            output += totalDays / 30 * 30;
            totalDays %= 30;

            output += totalDays;

            return output;
        }

        public static int PeriodInDays(this DateTime fromDate, DateTime toDate)
        {
            return toDate.Subtract(fromDate).TotalDays.PeriodInDays();
        }

        public static int PeriodInDays(this double totalDays)
        {
            return Convert.ToInt32(totalDays).PeriodInDays();
        }

        #region Private Methods
        private static object GetAttributeObject<T>(T enumerationValue, Type attributueType) where T : struct
        {
            var enumType = enumerationValue.GetType();
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a attribute for a potential friendly name
            //for the enum
            var memberInfo = enumType.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(attributueType, false);

                if (attrs != null && attrs.Length > 0)
                {
                    //Pull out the attribute object
                    return attrs[0];
                }
            }
            //If we have no attribute return null
            return null;
        }
        #endregion
    }
}
