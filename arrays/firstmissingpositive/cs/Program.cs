using System.Diagnostics;
using System.Numerics;

namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var nums = new int[] { 1, 2, 6, 3, 5, 4 };
        // var nums = new int[] { 2, 2, 2, 2, 2 };
        // var nums = new int[] { 3, 4, -1, 1 };
        // var nums = new int[] { 1, 1, 1, 1, 1 };

        var r = FirstMissingPositive(nums);

        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/first-missing-positive
    static int FirstMissingPositive(int[] nums)
    {
        if (nums.Length == 1)
        {
            if (nums[0] == 1)
                return 2;

            return 1;
        }

        bool oneExists = false;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
                oneExists = true;
        }

        if (!oneExists)
            return 1;

        for (int i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            if (num <= 0)
                continue;

            // The index is equal to the number, just mark as processed
            if (num == i)
            {
                nums[i] = GetProcessedMarker();
                continue;
            }

            // Either it means it's processed, or we've encountered a 'one'
            // No need to traverse
            if (nums[i] == GetProcessedMarker())
            {
                continue;
            }

            // The number is positive
            Traverse(nums, num);
        }

        if (!oneExists)
            return 1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != GetProcessedMarker())
                return i;
        }

        // We've reached the end of the array. 
        // Meaning, the result is nums.Length

        // What if nums[0] is equal to the length?
        // Imagine array
        // [3,2,1]
        // Is result 3? 
        // Nah, just because it's greater than the array size,
        // It doesn't mean that we should just ignore it
        // The answer should've been 4. Not 3.
        // There's a logic in the Traverse() method, that allocates nums[0] for overflows.
        // We're writing the minimum overflow to nums[0], so that we can compare it to the length of the array.
        if (nums[0] == nums.Length)
            return nums[0] + 1;

        return nums.Length;
    }

    static void Traverse(int[] nums, int num)
    {
        if (num > nums.Length - 1)
        {
            if (nums[0] <= 0)
                nums[0] = num;
            else if (nums[0] <= nums.Length - 1)
                nums[0] = num;
            else
                nums[0] = Math.Min(nums[0], num);

            return;
        }

        if (num <= 0)
            return;

        // meaning that's processed
        var newNum = nums[num];

        nums[num] = GetProcessedMarker();

        // ignore duplicates
        if (newNum == num || newNum == GetProcessedMarker())
            return;

        Traverse(nums, newNum);
    }

    static int GetProcessedMarker()
    {
        return (int)Math.Pow(2, 31);
    }

}
