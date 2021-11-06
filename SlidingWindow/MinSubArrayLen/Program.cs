using System;

namespace MinSubArrayLen
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] {2, 3, 1, 2, 4, 3};
            MinSubArrayLen(7, arr);
            Console.WriteLine("Hello World!");
        }
        
        static int MinSubArrayLen(int target, int[] nums) {
        
            int left = 0;
            int right = 0;
            int sum = 0;
            int minLength = Int32.MaxValue;
        
            while(right < nums.Length)
            {
                sum += nums[right++];
            
                while(sum >= target)
                {
                    minLength = Math.Min(minLength, right - left);
                    sum -= nums[left++];
                }            
            }
        
            return minLength == Int32.MaxValue ? 0 : minLength;
        }
        
    }
}