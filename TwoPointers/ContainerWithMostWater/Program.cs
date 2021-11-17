using System;

namespace ContainerWithMostWater
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://leetcode.com/problems/container-with-most-water/
            int[] input = new int[]
            {
                1,8,6,2,5,4,8,3,7
            };
            
            // O(N^2) solution
            var bruteForce = new BruteForce.BruteForce();
            var result = bruteForce.MaxArea(input);

            //O(N) solution
            var optimized = new TwoPointers.TwoPointers();
            var resultOptimized = optimized.MaxArea(input);
        }
    }
}
