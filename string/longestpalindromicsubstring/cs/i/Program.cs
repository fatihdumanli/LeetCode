using System;

namespace LongestPalindromicSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "cbbd";
            var result = LongestPalindrome(str);
            Console.WriteLine("Hello World!");
        }
        
        static string LongestPalindrome(string s)
        {
            int substrStart = 0;
            int substrEnd = 0;
            
            for(int i = 0; i < s.Length - 1; i++) {
            
                var case1 = ExpandFromMiddle(s, i, i + 1);
                var case2 = ExpandFromMiddle(s, i - 1, i + 1);

                if (case1[1] - case1[0] > substrEnd - substrStart)
                {
                    substrStart = case1[0];
                    substrEnd = case1[1];
                }
                
                else if (case2[1] - case2[0] > substrEnd - substrStart)
                {
                    substrStart = case2[0];
                    substrEnd = case2[1];
                }
            }
        
            return s.Substring(substrStart, substrEnd - substrStart + 1);
        }
    
        static int[] ExpandFromMiddle(string s, int left, int right) {
            
            while(left >= 0 && right <= s.Length - 1 && s[left] == s[right]) 
            {
                left--;
                right++;
            }
        
            return new int[] { left + 1, right - 1 };
        
        }
    }
}
