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
            return value.Split(new [] { "\r\n", "\r", "\n" }, options);
        }

        public static string Remove(this string value, string removable)
        {
            return value.Replace(removable, String.Empty);
        }

		public static int XThIndexOf(this string value, char ch, int count)
		{
			if (count < 1)
			{
				throw new ArgumentException($"{nameof(count)} cannot be less than zero or zero");
			}
			var index = -1;
			for (int i = 0; i < count; i++)
			{
				index++;
				index = value.IndexOf(ch, index);
				if (index == -1)
				{
					return -1;
				}
			}
			return index;
		}
	}
}
