namespace iii;

class Program
{
    static void Main(string[] args)
    {
        var s = "deeds";
        var r = CountSubstrings(s);
        Console.WriteLine(r);

        Console.WriteLine("Hello, World!");
    }

    // https://leetcode.com/problems/palindromic-substrings/
    static int CountSubstrings(string s)
    {
        var r = 0;

        for (int i = 0; i < s.Length; i++)
        {
            CountPalindromes(s, i, i + 1, ref r);
            CountPalindromes(s, i, i, ref r);
        }

        return r;
    }

    static void CountPalindromes(string s, int left, int right, ref int r)
    {
        while(left >= 0 && right < s.Length && s[left] == s[right])
        {
            r++;
            left--;
            right++;
        }
    }
}
