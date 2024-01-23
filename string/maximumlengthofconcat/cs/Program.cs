namespace cs;
public class Result
{
    public int val { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var words = new List<string>()
        {
            "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p"
        };
        
        //var words = new List<string>()
        //{
        //    "ab","cd","cde","cdef","efg","fgh","abxyz"
        //};

        //var words = new List<string>()
        //{
        //    "ab", "cd", "cde", "efg", "dfg"
        //};

        var r = MaxLength(words);

        Console.WriteLine(r);
        Console.WriteLine("Hello, World!");
    }

    // https://leetcode.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters/
    static int MaxLength(IList<string> arr) 
    {
        var result = new Result();

        DFS(arr, "", 0, result);

        return result.val;
    }

    static void DFS(IList<string> arr, string path, int index, Result result)
    {
        if (!IsUnique(path))
            return;

        result.val = Math.Max(result.val, path.Length);

        if (index == arr.Count)
            return;

        for (int i = index; i < arr.Count; i++)
        {
            DFS(arr, path + arr[i], i + 1, result);
        }
    }

    static bool IsUnique(string word)
    {
        var hashset = new HashSet<char>();

        foreach(var c in word)
        {
            if (hashset.Contains(c))
                return false;

            hashset.Add(c);
        }

        return true;
    }

    public static long GetBits(string word)
    {
        long num = 0;

        foreach(var c in word)
        {
            num |= 1 << 26 - (c - 97);
        }

        return num;
    }
}
