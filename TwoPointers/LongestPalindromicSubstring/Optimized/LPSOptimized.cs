using System;

namespace LongestPalindromicSubstring.BruteForce
{
    /// <summary>
    /// Inspired by Nick White's video: https://www.youtube.com/watch?v=y2BD4MJqV20
    /// Improved readability, changed the logic a bit.
    /// </summary>
    public class LPSOptimized : ILPSService
    {
        private const int RIGHT_INDEX = 1;
        private const int LEFT_INDEX = 0;
        
        public string GetLPS(string s)
        {
            int substrStartIndex = 0;
            int substrEndIndex = 0;

            for (int i = 0; i < s.Length; i++)
            {
                var case1 = ExpandFromMiddle(s, i, i);
                var case2 = ExpandFromMiddle(s, i, i + 1);

                if (case1[RIGHT_INDEX] - case1[LEFT_INDEX] > substrEndIndex - substrStartIndex)
                {
                    substrStartIndex = case1[LEFT_INDEX];
                    substrEndIndex = case1[RIGHT_INDEX];
                }
                
                if (case2[RIGHT_INDEX] - case2[LEFT_INDEX] > substrEndIndex - substrStartIndex)
                {
                    substrStartIndex = case2[LEFT_INDEX];
                    substrEndIndex = case2[RIGHT_INDEX];
                }

            }

            return s.Substring(substrStartIndex, substrEndIndex - substrStartIndex + 1);
        }

        private int[] ExpandFromMiddle(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            return new[] {left + 1, right - 1};
        }
        
    }
}