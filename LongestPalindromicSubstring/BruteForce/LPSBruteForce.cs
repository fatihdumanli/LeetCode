using System;

namespace LongestPalindromicSubstring.BruteForce
{
    /// <summary>
    /// Find all substrings: O(N^2)
    /// Check palindrome: 0(N)
    /// Overall time comlexity: O(N^3)
    /// </summary>
    public class LPSBruteForce : ILPSService
    {
        public string GetLPS(string s)
        {
            int lenOfLPS = 0;
            string LPS = "";
            
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    var substr = s.Substring(i, j - i  + 1);
                    if (IsPalindrome(substr))
                    {
                        if (substr.Length > lenOfLPS)
                            LPS = substr;
                        
                        lenOfLPS = Math.Max(lenOfLPS, substr.Length);
                        
                    }
                }
            }

            return LPS;
        }

        private bool IsPalindrome(string s)
        {
            var charArr = s.ToCharArray();
            Array.Reverse(charArr);
            var reversed = new string(charArr);
            return s == reversed;
        }
    }
}