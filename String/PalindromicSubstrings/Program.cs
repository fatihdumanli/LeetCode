using System;
using System.Linq;

namespace PalindromicSubstrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "racecar"; 
            Console.WriteLine(CountSubstrings(s));
        }
        
        static int CountSubstrings(string s) {

            int numberOfPalindromes = 0;
    
            for(int i = 0; i < s.Length; i++)
            {
                numberOfPalindromes++;
        
                var case1 = ExpandFromMiddle(s, i, i + 1);
                var case2 = ExpandFromMiddle(s, i - 1, i + 1);
            
                numberOfPalindromes += case1;
                numberOfPalindromes += case2;
            
            }
        
            return numberOfPalindromes;
        }
    
        static int ExpandFromMiddle(string s, int left, int right)
        {
            int palindromes = 0;
        
            while(left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
                palindromes++;
            }
        
            return palindromes;
        }
    }
}
