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

        PermuteHelper(new List<int>(), nums.ToList(), result);

        return result;
    }

    public static void PermuteHelper(List<int> prefix, List<int> input, List<IList<int>> result)
    {
        if (input.Count == 0)
        {
            result.Add(prefix);

            return;
        }

        for(int i = 0; i < input.Count; i++)
        {
            var newPrefix = new List<int>(prefix);
            newPrefix.Add(input[i]);

            var newInput = new List<int>(input);
            newInput.RemoveAt(i);

            PermuteHelper(newPrefix, newInput, result);
        }
    }
}
