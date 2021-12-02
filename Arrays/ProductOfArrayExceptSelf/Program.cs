using System;

namespace ProductOfArrayExceptSelf
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[]
            {
                1, 2, 3, 4                
            };

            var result = ProductExceptSelf(nums);
            
            Console.WriteLine("Hello World!");
        }

        static int[] ProductExceptSelf(int[] nums)
        {
            int[] prefix = new int[nums.Length + 1];
            int[] postfix = new int[nums.Length + 1];
            prefix[0] = 1;
            postfix[nums.Length] = 1;
        
            int[] result = new int[nums.Length];
        
            int product = 1;
        
            for(int i = 0; i < nums.Length; i++)
            {
                prefix[i + 1] = product *= nums[i];
            }
        
            product = 1;
        
            for(int i = nums.Length - 1; i >= 0; i--)
            {
                postfix[i] = product *= nums[i];
                result[i] = postfix[i + 1] * prefix[i];
            }
        
            return result;               
        }
    }
}
