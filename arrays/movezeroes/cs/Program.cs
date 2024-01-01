namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var nums = new int[] { 0, 1, 0, 3, 12 };

        MoveZeroes(nums);

        Console.WriteLine("Hello, World!");
    }

    static void MoveZeroes(int[] nums)
    {
        var ptr = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
                nums[ptr++] = nums[i];
        }

        while(ptr < nums.Length)
            nums[ptr++] = 0;
    }
}
