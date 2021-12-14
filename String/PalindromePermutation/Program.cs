using System;

namespace PalindromePermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "Tact Coa";
            var result = IsPalindromeOfAPermutation(s);
            Console.WriteLine("Hello World!");
        }

        static bool IsPalindromeOfAPermutation(string s)
        {
            s = s.ToLower();
            int[] charSet = new int[26];

            int a = 'a';
            int b = 'z';
            foreach (var c in s)
            {
                if(c < 97 || c > 122)
                    continue;
                
                charSet[c - 'a']++;
            }
            
            int oddCount = 0;
            foreach (var item in charSet)
            {
                if (item % 2 == 1)
                    oddCount++;
            }


            return oddCount <= 1;
        }
    }
}
