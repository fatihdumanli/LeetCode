using System;
using System.Linq;
using System.Linq.Expressions;

namespace RomanToInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            var val = RomanToInteger("MMMCCCXXXIII");
        }

        static int RomanToInteger(string s)
        {
            string[] symbols = {
                "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"
            };
            
            int[] values = new int[]      { 1000,    900,   500,    400,    100,    90,     50,    40,      10,    9,      5,    4,     1  };

            int i = 0;
            int total = 0;

            while (i < s.Length)
            {
                bool isFound = false;

                if (i + 2 <= s.Length)
                {
                    var twoCharSubs = s.Substring(i, 2);

                    for (int j = 0; j < symbols.Length; j++)
                    {
                        if (symbols[j] != twoCharSubs) continue;
                        i += 2;
                        total += values[j];
                        isFound = true;
                        break;
                    }
                }
        
                
                if(isFound)
                    continue;
                
                var oneCharSubstr = s.Substring(i, 1);

                for (int j = 0; j < symbols.Length; j++)
                {
                    if (symbols[j] != oneCharSubstr) continue;
                    i += 1;
                    total += values[j];
                }
            }
            
            
            return total;
        }
    }
}
