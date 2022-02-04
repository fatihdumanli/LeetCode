using System;
namespace SearchInRotatedSortedArray
{
    public static class NumberExtensions
    {
        public static bool IsBetween(this int number, int min, int max) => min <= number && number <= max;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[]
            {
                3,1
            };
            
            // 5,1,3 -- target = 5
            // 3,5,1
            // 1,3,5
            
            // 7,0,1,2,4,5,6
            // 4,5,6,7,0,1,2
            // 2,4,5,6,7,0,1
            var result = Search(nums, target: 1);
            Console.WriteLine("Hello World!");
        }
        static int Search(int[] nums, int target)
        {
            if (nums.Length == 0)
                return -1;

            int start = 0;
            int end = nums.Length - 1;
            
            return BinarySearch(nums, start, end, target);
        }
        
        static int BinarySearch(int[] nums, int start, int end, int target)
        {
            if (start > end)
                return -1;
            
            var middle = start + (end - start) / 2;
            
            if (nums[middle] == target)
                return middle;

            //Left hand-side is sorted
            if (nums[start] <= nums[middle])
            {
                //Imagine the input 4,5,6,7,0,1,2 and target is being 5
                if (target.IsBetween(nums[start], nums[middle]))
                    return BinarySearch(nums, start, middle - 1, target);

                //Imagine the input 4,5,6,7,0,1,2 and target is being 1
                return BinarySearch(nums, middle + 1, end, target);
            }
            
            //Right hand side is sorted
            //Imagine the input 7,0,1,2,4,5,6 and target is being 5
            if (target.IsBetween(nums[middle], nums[end]))
                return BinarySearch(nums, middle + 1, end, target);

            //Imagine the input 7,0,1,2,4,5,6 and target is being 0
            return BinarySearch(nums, start, middle - 1, target);

        }
    }
}
