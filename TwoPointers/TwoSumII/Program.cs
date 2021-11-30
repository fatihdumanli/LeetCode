using System;

namespace TwoSumII
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[]
            {
                2,3,4
            };

            TwoSum(nums, 6);
            
            Console.WriteLine("Hello World!");
        }

        static int[] TwoSum(int[] numbers, int target)
        {
            var pos = 0;
            while (pos < numbers.Length)
            {
                var diff = target - numbers[pos];

                var index = BinarySearch(numbers, pos + 1, numbers.Length - 1, diff);

                if (index != -1)
                    return new int[] { pos + 1, index + 1};
                pos++;
            }
            
            return new int[] { };
        }

        static int BinarySearch(int[] arr, int start, int end, int number)
        {
            if (start > end)
                return -1;
            
            var mid = (start + end) / 2;

            if (number < arr[mid])
                return BinarySearch(arr, start, mid - 1, number);

            if (number > arr[mid])
                return BinarySearch(arr, mid + 1, end, number);

            if (number == arr[mid])
                return mid;

            return -1;
        }
    }
}
