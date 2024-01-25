using System.Text.Json;

namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var candidates = new int[] { 4, 2, 8 };

        var r = CombinationSum(candidates, 8);

        Console.WriteLine("Hello, World!");
    }

    // https://leetcode.com/problems/combination-sum/
    public static IList<IList<int>> CombinationSum(int[] candidates, int target) {
        var result = new List<IList<int>>();

        Combine(0, candidates, new List<int>(), target, 0, result);

        return result;
    }

    public static void Combine(int index, int[] candidates, List<int> prefix, int target, int sum, List<IList<int>> result)
    {
        var json = ToJson(prefix);
        if (index >= candidates.Length)
            return;

        for (int i = 0; i < candidates.Length; i++)
        {
            var nextIndex = index + i;
            
            if (nextIndex >= candidates.Length)
            {
                return;
            }

            sum += candidates[nextIndex];
            prefix.Add(candidates[nextIndex]);

            if (sum == target)
            {
                result.Add(prefix.ToArray());
                sum -= candidates[nextIndex];
                prefix.RemoveAt(prefix.Count - 1);
                continue;
            }

            if (sum > target)
            {
                sum -= candidates[nextIndex];
                prefix.RemoveAt(prefix.Count - 1);
                continue;
            }

            Combine(nextIndex, candidates, prefix, target, sum, result);

            sum -= candidates[nextIndex];

            prefix.RemoveAt(prefix.Count - 1);
        }
    }

    public static string ToJson(object obj) 
    {
        return JsonSerializer.Serialize(obj);
    }
}
