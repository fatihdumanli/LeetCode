namespace iii;

class Program
{
    static void Main(string[] args)
    {
        var s = "ABAB";
        var r = CharacterReplacement(s, 2);

        Console.WriteLine(r);
        Console.WriteLine("Hello, World!");
    }

    // https://leetcode.com/problems/longest-repeating-character-replacement
    static int CharacterReplacement(string s, int k)
    {
        var freq = new int[26];

        var left = 0;
        var right = 0;
        var result = 1;

        while (right < s.Length)
        {
            var str = s.Substring(left, right - left + 1);

            freq[(int)s[right] - 65]++;

            int mostFrequent = 0;

            // Find the dominant character
            for (int i = 0; i < freq.Length; i++)
            {
                if (freq[i] > mostFrequent)
                    mostFrequent = freq[i];
            }

            if (right - left + 1 - mostFrequent <= k)
            {
                result = Math.Max(result, right - left + 1);
                right++;
            }
            else
            {
                freq[(int)s[left] - 65]--;
                freq[(int)s[right] - 65]--;
                left++;
            }
        }

        return result;
    }
}
