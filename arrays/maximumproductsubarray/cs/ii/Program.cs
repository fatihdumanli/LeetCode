using System.Runtime.InteropServices;

namespace ii;
class Program
{
    static void Main(string[] args)
    {
        //var nums = new int[]  { -2, 0, -1 };
        //var nums = new int[] { 2, -5, -2, -4, 3 };
        var nums = new int[] { 3, -1, 4 };
        var r = MaxProduct(nums);

        Console.WriteLine(r);
    }


    /// <summary>
    /// https://leetcode.com/problems/maximum-product-subarray/
    /// Intuition: Store current negative and positive values.   
    /// Reset cumulative max values because it's already been stored in 'result'.
    /// The key idea here is that any 'big' negative can be turned into the greatest maximum at any time.
    /// (e.g. -120 * -2 = 240)
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    static int MaxProduct(int[] nums)
    {
        var result = nums[0];
        var min = nums[0];
        var max = nums[0];
        
        for(int i = 1; i < nums.Length; i++)
        {
            // Candidates
            // 1: The current number
            // 2: Min * current number
            // 3: Max * current number
            result = Math.Max(result, Math.Max(max * nums[i], min * nums[i]));
            result = Math.Max(result, nums[i]);

            var tempMin = min;
            var tempMax = max;

            // Candidates
            // 1: Current number
            // 2: Previous min * current number
            // 3: Previous max * current number
            max = Math.Max(nums[i], Math.Max(tempMin * nums[i], tempMax * nums[i]));


            // Candidates
            // 1. Current number    
            // 2. Previous min * current number
            // 3: Previous max * current number
            min = Math.Min(nums[i], Math.Min(tempMin * nums[i], tempMax * nums[i]));
        }
        
        return result;
    }
}
