using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Day02
{
    public static class Extensions
    {

        public static Dictionary<long, long> splitInHalf(this string value)
        {
            if(value.Length == 1)
            {
                return null;
            }

            int middle = value.Count(char.IsDigit) / 2;

            string firstValue = value[0..middle];
            string lastValue = value[middle..];

            if (!long.TryParse(firstValue, out long start) || !long.TryParse(lastValue, out long end))
            {
                throw new ArgumentException("Invalid numeric values");
            }

            return new Dictionary<long, long> {
                { start, end }
};




        }

        public static bool IsInvalidId(this long id)
        {
            string s = id.ToString();

            if (s.Length % 2 != 0)
                return false;

            int half = s.Length / 2;
            return s[..half] == s[half..];
        }


        public static List<string> SplitBasedOnSeparator(this string value,char separator)
        {
            List<string> output = new List<string>();
            int start = 0;

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == separator)
                {
                    output.Add(value[start..i]);
                    start = i + 1;
                }
            }

            output.Add(value[start..]);

            return output;
        }


    }
}
