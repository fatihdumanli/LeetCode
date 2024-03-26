namespace cs;

class Program
{
    static void Main(string[] args)
    {
        // var nums = new int[] { 1, 2, 6, 3, 5, 4 };
        // var nums = new int[] { 2, 2, 2, 2, 2 };
        // var nums = new int[] { 3, 4, -1, 1 };
        // var nums = new int[] { 1, 1, 1, 1, 1 };
        var nums = new int[] { 1, 1 };

        var r = FirstMissingPositive(nums);

        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/first-missing-positive
    static int FirstMissingPositive(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            if (num <= 0)
            {
                // cannot be considered - mark with n + 1
                nums[i] = nums.Length + 1;
            }
        }

        for (int i = 0; i < nums.Length; i++)
        {
            var num = Math.Abs(nums[i]);

            // it cannot be considered - it was negative or zero
            if (num > nums.Length)
                continue;
            // (ith element) represent the integer i + 1
            // 0 -> 1 
            // 1 -> 2 
            // make the element negative (marking as exist)

            // it's already negative - already marked as exists. 
            // multiplying it with -1 one more time would result in
            // unmarking the element
            if (nums[num - 1] < 0)
                continue;

            nums[num - 1] = -1 * (nums[num - 1]);
        }

        for (int i = 0; i < nums.Length; i++)
        {
            // if it's positive, that means the positive integer did not exist in the original array.
            if (nums[i] > 0)
                return i + 1;
        }

        // all of them exist, return n + 1
        return nums.Length + 1;
    }
}
