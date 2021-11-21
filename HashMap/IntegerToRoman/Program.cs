using System;
using System.Collections.Generic;
using System.Text;

namespace IntegerToRoman
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = 3922 / 1000;
            //IntToRoman(10);
            IntToRomanOptimized(1994);
        }
        
        private static string IntToRomanOptimized(int num)
        {
            string[] symbols = new string[] { "M",    "CM",   "D",   "CD",    "C",   "XC",   "L",   "XL",    "X",   "IX",   "V",  "IV",  "I"  };
            int[] dividers = new int[]      { 1000,    900,   500,    400,    100,    90,     50,    40,      10,    9,      5,    4,     1  };

            var pos = 0;

            StringBuilder sb = new StringBuilder();
            
            while (num > 0)
            {
                //3922 / 1000 = 3
                //3922 % 1000 = 922
                var divideTo = dividers[pos];
                var digit = num / divideTo;

                var currentSymbol = symbols[pos];
                for (int i = 0; i < digit; i++)
                    sb.Append(currentSymbol);

                num = num % divideTo;
                pos++;
            }

            return sb.ToString();
        }
        
        
        
        /*  BEGIN: My first approach using 4 hashmaps & stack.
         I used a stack because my approach was starting from the smallest digit. I needed to reverse the results.
         Beats 40% of the C# submissions. There are still room for improvement though */
        private static string IntToRoman(int num)
        {
            Stack<string> result = new Stack<string>();
            int power = 0;
            
            while(power < num.ToString().Length)
            {
                var digit = (num / Math.Pow(10, power)) % 10;
                var roman = GetRoman((int)digit, power);
                result.Push(roman);
                power++;
            }

            string finalResult = "";
            while (result.Count > 0)
            {
                finalResult += result.Pop();
            }

            return finalResult;
        }
        private static string GetRoman(int digit, int power)
        {
            if (digit == 0)
                return string.Empty;
            
            Dictionary<int, string> powerZero = new Dictionary<int, string>();
            powerZero.Add(1, "I");
            powerZero.Add(2, "II");
            powerZero.Add(3, "III");
            powerZero.Add(4, "IV");
            powerZero.Add(5, "V");
            powerZero.Add(6, "VI");
            powerZero.Add(7, "VII");
            powerZero.Add(8, "VIII");
            powerZero.Add(9, "IX");
            
            Dictionary<int, string> powerOne = new Dictionary<int, string>();
            powerOne.Add(1, "X");
            powerOne.Add(2, "XX");
            powerOne.Add(3, "XXX");
            powerOne.Add(4, "XL");
            powerOne.Add(5, "L");
            powerOne.Add(6, "LX");
            powerOne.Add(7, "LXX");
            powerOne.Add(8, "LXXX");
            powerOne.Add(9, "XC");
            
            Dictionary<int, string> powerTwo = new Dictionary<int, string>();
            powerTwo.Add(1, "C");
            powerTwo.Add(2, "CC");
            powerTwo.Add(3, "CCC");
            powerTwo.Add(4, "CD");
            powerTwo.Add(5, "D");
            powerTwo.Add(6, "DC");
            powerTwo.Add(7, "DCC");
            powerTwo.Add(8, "DCCC");
            powerTwo.Add(9, "CM");
            
            Dictionary<int, string> powerThree = new Dictionary<int, string>();
            powerThree.Add(1, "M");
            powerThree.Add(2, "MM");
            powerThree.Add(3, "MMM");
            
            if (power == 0)
                return powerZero[digit];

            if (power == 1)
                return powerOne[digit];

            if (power == 2)
                return powerTwo[digit];

            if (power == 3)
                return powerThree[digit];

            return string.Empty;
        }
        
        /*  END: My first approach using 4 hashmaps & stack. Beats 40% of the C# submissions. There are still room for improvement though */

    }
}