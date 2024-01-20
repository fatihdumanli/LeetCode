namespace iii;

class Program
{
    static void Main(string[] args)
    {
        var s = "abcabcbb";
        var r = LengthOfLongestSubstring(s);
        Console.WriteLine(r);
        Console.WriteLine("Hello, World!");
    }

    // https://leetcode.com/problems/longest-substring-without-repeating-characters
    static int LengthOfLongestSubstring(string s) 
    {
        if (string.IsNullOrEmpty(s))
            return 0;

        var result = 1;
        var hashset = new HashSet<char>();

        var left = 0;
        var right = 0;

        while (right < s.Length)
        {
            var testStr = s.Substring(left, right - left + 1);

            if (!hashset.Contains(s[right]))
            {
                hashset.Add(s[right]);
                result = Math.Max(result, right - left + 1);
                right++;
            }
            else
            {
                while (s[left] != s[right])
                {
                    hashset.Remove(s[left]);
                    left++;
                }

                left++;
                right++;
            }
        }

        return result;
    }
}
