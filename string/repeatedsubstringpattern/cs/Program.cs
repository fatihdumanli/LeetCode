using System.Text;

namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var s = "aba";

        var r = RepeatedSubstringPattern(s);

        Console.WriteLine(r);
        Console.WriteLine("Hello, World!");
    }

    // https://leetcode.com/problems/repeated-substring-pattern/
    static bool RepeatedSubstringPattern(string s) {

        // Step 1: Get all substrings starting from first character
        var substrings = GetFirstSubstrings(s);


        // Step 2: Try out each substring if they constitute the string a
        var sb = new StringBuilder();

        foreach(var sub in substrings)
        {
            if (s.Length % sub.Length != 0)
                continue;

            var times = s.Length / sub.Length;

            for (int i = 0; i < times; i++)
            {
                sb.Append(sub);
            }

            if (sb.ToString() == s)
                return true;

            sb.Clear();
        }

        return false;
    }

    static List<string> GetFirstSubstrings(string s)
    {
        var list = new List<string>();

        var sb = new StringBuilder();

        var right = 0;

        while (right < s.Length - 1)
        {
            sb.Append(s[right]);
            list.Add(sb.ToString());
            right++;
        }

        return list;
    }
}
