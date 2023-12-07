using System;
using System.Globalization;

namespace IndexOfFirstOccurence
{
    class Program
    {
        static void Main(string[] args)
        {
            var haystack = "seboissad";
            var needle = "sad";

            var r = StrStr(haystack, needle);
            Console.WriteLine(r);
       }

        static int StrStr(string haystack, string needle)
        {
            var hidx = 0;

            for(int i = 0; i < needle.Length; i++)
            {
                // move the index on haystack
                if(haystack[hidx] != needle[i])
                {
                    i = 0;
                    hidx++;
                    continue;
                }
                else
                {
                    // the current haystack char = current needle char
                    // 
                    if(hidx == needle.Length - 1)
                        return hidx - needle.Length;

                    hidx++;
                }
            }
            
            return -1;
        }
    }
}




