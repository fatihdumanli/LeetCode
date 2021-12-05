using System;

namespace FindMinimumInRotatedSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[]
            {
                2, 1
            };
            
            
            // 0, 1, 2

            var result = FindMin(arr);
            
            Console.WriteLine("Hello World!");
        }

        static int FindMin(int[] nums)
        {
            if (nums.Length == 0) return -1;
            if (nums.Length == 1) return nums[0];

            int start = 0;
            int end = nums.Length - 1;

            return BinarySearch(nums, start, end);
        }

        static int BinarySearch(int[] nums, int start, int end, int min = Int32.MaxValue)
        {
            if (start > end)
                return min;

            var middle = start + (end - start) / 2;
            
            /*
             * If the starting element is less than the middle element,
             * That means the middle element is a part of a sorted array
             * And the minimum element is equal to nums[start],
             * And we need to seek the minimum at the right hand side of the array.
             * Imagine such an array
             * [ 3,4,5,1,2 ]
             */
            if (nums[start] <= nums[middle])
            {
                min = Math.Min(min, nums[start]);
                return BinarySearch(nums, middle + 1, end, min);
            }
            
            /*
             * Otherwise, let's imagine the middle element is less than the starting element,
             * That would mean something is wrong with the left-hand side of the array.
             * And the middle element is a part of a sorted array such that its starting element is the middle,
             * And each element that comes after the middle will be greater than the middle.
             * That would mean the middle element is the minimum so far,
             * And we need to seek smaller values at the right-hand side of the array.
             * [5,1,2,3,4]
             */
            min = Math.Min(min, nums[middle]);
            return BinarySearch(nums, start, middle - 1, min);
        }
    }
}
