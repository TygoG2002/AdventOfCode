using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Day02
{
    public static class Extensions
    {

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
