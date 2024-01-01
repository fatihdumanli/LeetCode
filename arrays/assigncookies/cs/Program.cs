namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var g = new int[] { 1, 2 };
        var s = new int[] { 1, 2, 3 };

        var r = FindContentChildren(g, s);

        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/assign-cookies
    static int FindContentChildren(int[] g, int[] s)
    {
        Array.Sort(g);
        Array.Sort(s);

        var childPtr = 0;
        var cookiePtr = 0;
        var result = 0;

        while (cookiePtr < s.Length && childPtr < g.Length)
        {
            var cookieNeeded = g[childPtr];

            if (s[cookiePtr]  >= cookieNeeded)
            {
                result++;
                childPtr++;
            }

            cookiePtr++;
        }

        return result;
    }
}
