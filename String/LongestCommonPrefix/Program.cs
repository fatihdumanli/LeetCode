using System;
using System.Collections.Generic;
using System.Text;

namespace LongestCommonPrefix
{
    class Program
    {
        static void Main(string[] args)
        {
            var strs = new string[]
            {
                "flower", "flow", "flight"
            };

            var result = LongestCommonPrefix(strs);
            Console.WriteLine("Hello World!");
        }
        
        static string LongestCommonPrefix(string[] strs)
        {
            var shortestStringLength = Int32.MaxValue;
            foreach (var str in strs)
            {
                if (str.Length == 0) return string.Empty;
                shortestStringLength = Math.Min(shortestStringLength, str.Length);
            }
            int pos = 0;
            while (pos < shortestStringLength)
            {
                var charToCompare = strs[0][pos];
                for (int i = 1; i < strs.Length; i++)
                {
                    if(strs[i][pos] == charToCompare) continue;
                    return strs[0].Substring(0, pos);
                }
                pos++;
            }

            return strs[0].Substring(0, pos);
        }
    }
}
