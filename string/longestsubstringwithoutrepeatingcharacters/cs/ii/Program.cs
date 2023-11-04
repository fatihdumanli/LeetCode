namespace ii;
class Program
{
    static void Main(string[] args)
    {
        var s = "abcabcbb";
        var r = LengthOfLongestSubstring(s);

        Console.WriteLine(r);
    }

    /// https://leetcode.com/problems/longest-substring-without-repeating-characters
    static int LengthOfLongestSubstring(string s)
    {
        if(s.Length == 0)
            return 0;
        
        var left = 0;
        var right = 0;
        var maxLength = Int32.MinValue;
        var hashset = new HashSet<char>();
        
        while(right < s.Length)
        {
            if(!hashset.Contains(s[right]))
            {
                hashset.Add(s[right]);
                maxLength = Math.Max(maxLength, right - left + 1);
                right++;
            }
            else
            {
                hashset.Remove(s[left]);
                left++;
            }
        }

        return maxLength;
    }
}
