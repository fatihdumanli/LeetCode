namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var nums = new int[] {0,1,2,2,3,0,4,2};

        var r = RemoveElement(nums, 2);

        Console.WriteLine("Hello, World!");
    }

    // https://leetcode.com/problems/remove-element
    static int RemoveElement(int[] nums, int val) 
    {
        var left = 0;
        var right = 0;

        while (right < nums.Length)
        {
            if (nums[right] != val)
            {
                nums[left++] = nums[right];
            }

            right++;
        }

        return left;
    }
}
