namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var nums = new int[] { 91473, 45388, 24720, 35841, 29648, 77363, 86290, 58032, 53752, 87188, 34428, 85343, 19801, 73201 };
        var r = NumberOfSubarrays(nums, 4);
        Console.WriteLine(r);
        Console.WriteLine("Hello, World!");
    }

    // https://leetcode.com/problems/count-number-of-nice-subarrays/
    static int NumberOfSubarrays(int[] nums, int k)
    {
        var left = 0;
        var right = 0;
        var result = 0;
        var firstOddPosition = -1;
        var numOfOdds = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 == 1)
            {
                firstOddPosition = i;
                break;
            }
        }

        if (firstOddPosition == -1)
            return 0;

        while (right < nums.Length)
        {
            if (nums[right] % 2 == 1)
                numOfOdds++;

            if (numOfOdds < k)
            {
                right++;
                continue;
            }

            if (numOfOdds == k)
            {
                result++;
                result += firstOddPosition - left;
                right++;
            }
            else if (numOfOdds > k)
            {
                left = firstOddPosition + 1;
                numOfOdds--;

                var ptr = left;
                while (nums[ptr] % 2 == 0)
                    ptr++;

                firstOddPosition = ptr;
                numOfOdds--;
            }
        }

        return result;
    }
}
