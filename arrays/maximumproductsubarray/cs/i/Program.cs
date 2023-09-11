using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MaximumProductSubArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[]
            {
                -3, -2, -1, 4
            };

            var result = MaxProduct(nums);
            Console.WriteLine(result);
        }
        
        static int MaxProduct(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            if (nums.Length == 1)
                return nums[0];

            int min = 1;
            int max = 1;
            
            int result = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                int tempMin = min;
                min = Math.Min(Math.Min(nums[i], nums[i] * min), nums[i] * max);
                max = Math.Max(Math.Max(nums[i], nums[i] * max), nums[i] * tempMin);

                result = Math.Max(result, max);
            }
            
            return result;
        }
    }
}
