using System.Text.Json;

namespace ii;

class Program
{
    static void Main(string[] args)
    {
        var nums = new int[] { -4, -1, -1, -1, -1, 0, 1, 1, 1, 2 };
        
        var r = ThreeSum(nums);

        Console.WriteLine(JsonSerializer.Serialize(r));
    }

    // https://leetcode.com/problems/3sum
    // Thought process:
    // The idea here is that if we have two numbers L and R
    // There must be only one value that satisfies the equation L + R + x = 0
    // So we just need to check if the right hand side of the array includes such x.
    // To focus accurately on the right handside, we also keep the last occurence of any number in the hashmap.
    // We basically ignore a number in the hashmap if it's last occurence is <= R.
    // 
    // For deduplication;
    // All L and R pairs are unique. 
    // So we basically skip a number if we previously pointed it by the pointer L
    // Same goes for the R too, if in any of previous steps, the number is pointed by the pointer R
    // Since it doesn't make sense to execute search for the same R's over and over again,
    // We simply skip that R.
    // Check the lines 49 and 64.
    static IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        
        var dict = new Dictionary<int, int>();

        for(int i = 0; i < nums.Length; i++)
        {
            if(dict.ContainsKey(nums[i]))
                dict[nums[i]] = i;
            else
                dict.Add(nums[i], i);
        }

        var result = new List<IList<int>>();
        var leftVal = Int32.MinValue;

        for(int i = 0; i < nums.Length - 1; i++)
        {
            if(nums[i] == leftVal)
                continue;
            
            leftVal = nums[i];

            var ptr = i + 1;
            
            while(ptr < nums.Length)
            {
                var rightVal = nums[ptr];
                var seekFor = 0 - (leftVal + rightVal);

                if(dict.ContainsKey(seekFor) && dict[seekFor] > ptr)
                    result.Add(new List<int>() { leftVal, rightVal, seekFor });
                
                while(ptr < nums.Length && nums[ptr] == rightVal)
                    ptr++;
            }
        }

        return result;
    }
}
