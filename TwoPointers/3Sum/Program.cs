using System;
using System.Collections.Generic;

namespace _3Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[]
            {
                -1, 0, 1, 2, -1, -4
            };

            var result = ThreeSum(nums);
        }
        
        
        static IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();

            Array.Sort(nums);
            
            //Optimizations
            if(nums.Length < 3)
                return result;
        
            if(nums[0] > 0 || nums[^1] < 0)
                return result;
            //Optimizations
        
        
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if(i > 0 && nums[i] == nums[i - 1])
                    continue;

                var left = i + 1;
                var right = nums.Length - 1;

                while (left < right)
                {
                    var sum = nums[i] + nums[left] + nums[right];

                    if (sum < 0) left++;
                    else if (sum > 0) right--;
                    else
                    {
                        result.Add(new List<int>()
                        {
                            nums[i], nums[left], nums[right]
                        });

                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;

                        left++;
                        right--;
                    }
                }
            }

            return result;
        }
        
        /* My first attempt */
        /*
        static IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums == null || nums.Length < 3)
                return new List<IList<int>>();

            HashSet<string> resultSet = new HashSet<string>();
            
            var result = new List<IList<int>>();
            Array.Sort(nums);
            
            var pos = 0;
            var left = pos + 1;
            var right = nums.Length - 1;


            for (int i = 0; i < nums.Length; i++)
            {
                var current = nums[i];
                
                while (left < right)
                {
                    var total = current + nums[left] + nums[right];

                    if (total < 0)
                        left++;
                    
                    else if (total > 0)
                        right--;
                    
                    else
                    {
                        var sublist = new List<int>()
                        {
                            current, nums[left], nums[right]
                        };

                        string encoding = string.Join(null, sublist);
                        if (!resultSet.Contains(encoding))
                        {
                            result.Add(sublist);
                            resultSet.Add(encoding);
                        }
                        left++;
                        right--;
                    }
                }
                
                pos++;
                left = pos + 1;
                right = nums.Length - 1;
            }
            
            return result;
        }
        */
    }
}
