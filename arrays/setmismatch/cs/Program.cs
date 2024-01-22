namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var nums = new int[] { 1, 2, 2, 4 };
        var r = FindErrorNums(nums);

        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/set-mismatch
    static int[] FindErrorNums(int[] nums) {
        int duplicate = Int32.MinValue;
        
        var hashset = new HashSet<int>();
        
        foreach(var num in nums)
        {
            if (hashset.Contains(num))
                duplicate = num;
            else
                hashset.Add(num);
        }
        
        for(int i = 1; i < 10000; i++)
        {
            if (!hashset.Contains(i))
                return new int[] { duplicate, i };
        }
        
        return new int[] { -1, -1 };
    }
}
