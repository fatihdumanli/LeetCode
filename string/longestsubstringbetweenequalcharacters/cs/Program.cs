namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var s = "afdfsffda";
        var r = MaxLengthBetweenEqualCharacters(s);

        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/largest-substring-between-two-equal-characters/
    public static int MaxLengthBetweenEqualCharacters(string s) 
    {
        // key: character, value list of positions
        var dict = new Dictionary<char, int[]>();

        for(int i = 0; i < s.Length; i++)
        {
            if (dict.ContainsKey(s[i]))
            {
                dict[s[i]][0] = Math.Min(dict[s[i]][0], i);
                dict[s[i]][1] = Math.Max(dict[s[i]][1], i);
            }
            else
            {
                var arr = new int[2];
                arr[0] = i;
                arr[1] = i;

                dict.Add(s[i], arr);
            }
        }

        var max = -1;

        foreach(var kv in dict)
        { 
            if (kv.Value[0] == kv.Value[1])
                continue;

            max = Math.Max(max, kv.Value[1] - kv.Value[0] - 1);
        }

        return max;
    }
}
