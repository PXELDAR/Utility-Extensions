using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace PXELDAR
{
    public static class TypeExtensions
    {
        //===================================================================================

        private static readonly Regex UnixLineBreak = new Regex("(?<!\r)\n");
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        //===================================================================================

        public static string EscapeFormattingBraces(this string s)
        {
            return s.Replace("{", "{{").Replace("}", "}}");
        }

        //===================================================================================

        public static TValue GetWithDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defVal = default(TValue))
        {
            TValue val;
            if (dictionary.TryGetValue(key, out val))
                return val;

            return defVal;
        }

        //===================================================================================

        public static IEnumerable<string> SplitBy(this string str, int charCount)
        {
            int pos = 0;
            do
            {
                yield return str.Substring(pos, Math.Min(charCount, str.Length - pos));
                pos += charCount;
            }
            while (pos < str.Length);
        }

        //===================================================================================

        public static string ToTimeString(this long value)
        {
            return ToTimeString((double)value);
        }

        //===================================================================================

        public static string ToTimeString(this double value)
        {
            return ToTimeString(TimeSpan.FromMilliseconds(value));
        }

        //===================================================================================

        public static string ToTimeString(this TimeSpan value)
        {
            return value.ToString(@"hh\:mm\:ss");
        }

        //===================================================================================

        public static string ToTimeWithTotalHoursString(this TimeSpan timeSpan)
        {
            return $"{(int)timeSpan.TotalHours}:{timeSpan:mm\\:ss}";
        }

        //===================================================================================

        public static string ToCommaSeparatedString(this int value)
        {
            return ToCommaSeparatedString((long)value);
        }

        //===================================================================================

        public static string ToTwoDigitString(this int value)
        {
            return value < 10 ? string.Format("0{0}", value) : value.ToString();
        }

        //===================================================================================

        public static string ToCommaSeparatedString(this double value)
        {
            return ToCommaSeparatedString((long)Math.Round(value, MidpointRounding.AwayFromZero));
        }

        //===================================================================================

        public static string ToCommaSeparatedString(this long value)
        {
            return value.ToString("#,0", CultureInfo.InvariantCulture);
        }

        //===================================================================================

        public static string ToCommaSeparatedStringWithFractional(this double value)
        {
            return value.ToString("N2", CultureInfo.InvariantCulture).TrimEnd('0').TrimEnd('.');
        }

        //===================================================================================

        public static string ToCommaSeparatedStringFractionalOnly(this double value)
        {
            return value.ToString("0.00", CultureInfo.InvariantCulture).Split('.')[1];
        }

        //===================================================================================

        public static string ToShortenedString(this double value, int digits = 4, string format = "#,0")
        {
            return ToShortenedString((long)value, digits, format);
        }

        //===================================================================================

        public static string ToShortenedString(this long value, int digits = 4, string format = "#,0")
        {
            string pref = "";
            decimal correctNumber = value;
            double a = Math.Pow(10, digits);

            if (value >= Math.Pow(10, 9))
            {
                correctNumber = value * (decimal)Math.Pow(10, -9);
                pref = "B";
            }
            else if (value >= Math.Pow(10, 6))
            {
                correctNumber = value * (decimal)Math.Pow(10, -6);
                pref = "M";
            }
            else if (value >= Math.Pow(10, digits))
            {
                correctNumber = (decimal)(value * 0.001);

                if (correctNumber + 1 > 1000)
                {
                    correctNumber = 1;
                    pref = "M";
                }
                else
                {
                    pref = "K";
                }
            }

            correctNumber = Math.Floor(correctNumber * 10) / 10;
            if (correctNumber < 10 && pref != string.Empty)
                format += ".0";

            return correctNumber.ToString(format, CultureInfo.InvariantCulture) + pref;
        }

        //===================================================================================

        public static string ToShortcutK(this double value, byte digits, string format = "#,0", string moreDigitsFormat = "#,0K")
        {
            if (value < Math.Pow(10, digits))
            {
                return value.ToString(format, CultureInfo.InvariantCulture);
            }

            return Convert.ToUInt64(value / 1000).ToString(moreDigitsFormat, CultureInfo.InvariantCulture);
        }

        //===================================================================================

        public static string ToShortenedBytesString(this long value)
        {
            double valueGb = BytesToGb(value, 1);
            if (valueGb >= 1)
            {
                return valueGb + " GB";
            }

            double valueMb = BytesToMb(value, 0);
            if (valueMb > 0)
            {
                return valueMb + " MB";
            }

            double valueKb = BytesToKb(value, 0);
            if (valueKb > 0)
            {
                return valueKb + " KB";
            }

            return value + " B";
        }

        //===================================================================================

        public static string ToShortenedBytesString(this int value)
        {
            return ((long)value).ToShortenedBytesString();
        }

        //===================================================================================

        public static double BytesToGb(this long value, int decimals)
        {
            return Math.Round(value / 1024.0 / 1024.0 / 1024.0, decimals);
        }

        //===================================================================================

        public static double BytesToMb(this long value, int decimals)
        {
            return Math.Round(value / 1024.0 / 1024.0, decimals);
        }

        //===================================================================================

        public static double BytesToMb(this int value, int decimals)
        {
            return ((long)value).BytesToMb(decimals);
        }

        //===================================================================================

        public static double BytesToKb(this long value, int decimals)
        {
            return Math.Round(value / 1024.0, decimals);
        }

        //===================================================================================

        public static double BytesToKb(this int value, int decimals)
        {
            return ((long)value).BytesToKb(decimals);
        }

        //===================================================================================

        public static DateTime ToDateTime(this long unixTimeMs)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddMilliseconds(unixTimeMs);
        }

        //===================================================================================

        public static T GetUnsafe<T>(this System.WeakReference<T> weakReference)
            where T : class
        {
            T val;
            if (!weakReference.TryGetTarget(out val))
            {
                throw new InvalidOperationException("GetUnsafe failed");
            }

            return val;
        }

        //===================================================================================

        public static long ToUnixTime(this DateTime dt)
        {
            return (long)(dt - UnixEpoch).TotalSeconds;
        }

        //===================================================================================

        public static long ToUnixTimeTotalMilliseconds(this DateTime dt)
        {
            return (long)(dt - UnixEpoch).TotalMilliseconds;
        }

        //===================================================================================

        public static string NormalizeMultiline(this string str)
        {
            return str == null ? null : UnixLineBreak.Replace(str.Trim(), "\r\n");
        }

        //===================================================================================

        public static string ToOrdinal(this int number)
        {
            if (number % 100 == 11 || number % 100 == 12 || number % 100 == 13)
            {
                return number + "th";
            }

            switch (number % 10)
            {
                case 1: return number + "st";
                case 2: return number + "nd";
                case 3: return number + "rd";
                default: return number + "th";
            }
        }

        //===================================================================================

        public static string GetShortName(string name, int maxLength = 20, string changeMaxString = "...")
        {
            if (name == null)
                return "";

            if (name.Length > maxLength)
            {
                if (maxLength >= changeMaxString.Length)
                    return name.Substring(0, maxLength - changeMaxString.Length) + changeMaxString;

                return name.Substring(0, maxLength);
            }

            return name;
        }

        //===================================================================================

        public static IList<T> GetItemsByIndex<T>(this IList<T> list, IList<int> indexes)
        {
            return list.Where((value, index) => indexes.Contains(index)).ToList();
        }

        //===================================================================================

        public static Color GetColorFromHex(string hex, double transparency)
        {
            var hexValue = uint.Parse(hex.Replace("#", ""), NumberStyles.HexNumber);
            var r = (byte)((hexValue >> 16) & 0xff);
            var g = (byte)((hexValue >> 8) & 0xff);
            var b = (byte)(hexValue & 0xff);
            var a = (byte)(Math.Clamp(transparency, 0, 1) * 255);
            return new Color(r, g, b, a);
        }

        //===================================================================================
    }
}