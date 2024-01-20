namespace ii;

class Program
{
    static void Main(string[] args)
    {
        var s = "ab";
        var t = "A";

        var r = MinWindow(s, t);
        Console.WriteLine(r);

        Console.WriteLine("Hello, World!");
    }

    // https://leetcode.com/problems/minimum-window-substring/
    static string MinWindow(string s, string t) {

        var result = string.Empty;
        var resultLength = Int32.MaxValue;
        int[] freq = new int[52];
        int[] req = new int[52];

        freq[GetIndex(s[0])]++;

        int left = 0;
        int right = 0;

        for (int i = 0; i < t.Length; i++)
            req[GetIndex(t[i])]++;
                
        while (right < s.Length)
        {
            if (Contains(req, freq))
            {
                if (right - left + 1 < resultLength)
                {
                    result = s.Substring(left, right - left + 1);
                    resultLength = result.Length;
                }

                // Shrink
                // lowercase safety
                freq[GetIndex(s[left])]--;
                left++;
            }
            else
            {
                right++;
                if (right < s.Length)
                    freq[GetIndex(s[right])]++;
            }
        }

        return result;
    }

    static bool Contains(int[] req, int[] freq)
    {
        for (int i = 0; i < req.Length; i++)
        {
            if (req[i] == 0)
                continue;

            if (req[i] > freq[i])
                return false;
        }

        return true;
    }

    static int GetIndex(char c)
    {
        if ((int)c >= 97)
            return (int)c - 97;
        return 26 + (int)c - 65;
    }
}
