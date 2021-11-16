using System;
using System.Diagnostics;
using System.Linq;

namespace LongestPalindromicSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "aaaa";
            Console.WriteLine($"Finding Longest Palindromic Substring in the string {str}");
            LongestPalindrome(str);
        }

        static string LongestPalindrome(string s)
        {
            var lpsFacade = new LPSFacade();

            Stopwatch timer = new Stopwatch();
            timer.Start();
            var lpsBruteForceResult = lpsFacade.LPSBruteForce(s);
            timer.Stop();
            Console.WriteLine($"Brute Force Took {timer.ElapsedMilliseconds} ms. Longest Palindrome Substring: {lpsBruteForceResult}. ");
            
            timer.Reset();
            timer.Start();
            var lpsOptimizedResult = lpsFacade.LPSOptimized(s);
            timer.Stop();
            Console.WriteLine($"Optimized Solution took {timer.ElapsedMilliseconds} ms. Longest Palindrome Substring: {lpsBruteForceResult}. ");

            return lpsOptimizedResult;
        }

   
    }
}
