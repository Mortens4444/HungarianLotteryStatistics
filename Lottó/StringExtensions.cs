using System;

namespace Lottó
{
    public static class StringExtensions
    {
        public static string[] SplitOnNewLines(this string value)
        {
            return value.SplitOnNewLines(StringSplitOptions.None);
        }

        public static string[] SplitOnNewLines(this string value, StringSplitOptions options)
        {
            return value.Split(new [] { "\r\n", "\r" }, options);
        }

        public static string Remove(this string value, string removable)
        {
            return value.Replace(removable, String.Empty);
        }
    }
}
