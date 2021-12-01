// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;

namespace TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] {3, 2, 4};
            var target = 6;
            var result = TwoSum(nums, target);
            
            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
        }

        static int[] TwoSum(int[] nums, int target)
        {

            Dictionary<int, int> hashmap = new Dictionary<int, int>();
            
            for(int i = 0; i < nums.Length; i++)
            {
                var diff = target - nums[i];

                if (hashmap.ContainsKey(diff))
                    return new int[] {i, hashmap[diff]};
                else if(!hashmap.ContainsKey(nums[i]))
                    hashmap.Add(nums[i], i);
            }
        
            return new int[] {};
        }
    }
}