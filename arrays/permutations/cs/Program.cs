namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var nums = new int[] { 1, 2, 3 };

        var r = Permute(nums);

        Console.WriteLine("Hello, World!");
    }

    public static IList<IList<int>> Permute(int[] nums) 
    {
        var result = new List<IList<int>>();

        var prefix = new int[nums.Length];

        for (int i = 0; i < prefix.Length; i++)
            prefix[i] = 99;

        PermuteHelper(prefix, nums, c: 0, result);

        return result;
    }

    // https://leetcode.com/problems/permutations/
    public static void PermuteHelper(int[] prefix, int[] input, int c, List<IList<int>> result)
    {
        if (prefix[prefix.Length - 1]  != 99)
        {
            result.Add(prefix);

            return;
        }

        for(int i = 0; i < input.Length; i++)
        {
            if (input[i] == 99)
                continue;

            var temp = input[i];

            prefix[c] = input[i];

            input[i] = 99;

            PermuteHelper(prefix, input, c + 1, result);

            input[i] = temp;
        }
    }
}
