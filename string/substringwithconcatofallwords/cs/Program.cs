using System.Text;
using System.Text.Json;

namespace cs;

class Program
{
    static void Main(string[] args)
    {
         var words = new string[] { "ab", "ba", "ab", "ba" };
         var s = "abaababbaba";
        
        var r = FindSubstring(s, words);

        Console.WriteLine(JsonSerializer.Serialize(r));
    }

    // foo, bar
    // "barfoothefoobarman" -> 0,9
    //
    // foo, bar the
    // "barfoofoobarthefoobarman" -> 6, 9 ,12 
    // https://leetcode.com/problems/substring-with-concatenation-of-all-words
    public static IList<int> FindSubstring(string s, string[] words) {
        var result = new List<int>();
        var step = words[0].Length;
        var targetLength = words[0].Length * words.Length;

        // key: word, value: num of left rights to use
        var dict = new Dictionary<string, int>();

        foreach(var w in words)
        {
            if (dict.ContainsKey(w))
                dict[w]++;
            else
                dict.Add(w, 1);

        }
        var copyDict = dict.ToDictionary(e => e.Key, e => e.Value);

        var left = 0;
        var right = 0;
        var lastStart = 0;

        var sb = new StringBuilder();
        while (right < s.Length)
        {
            sb.Append(s[right]);

            if (right - left + 1 == step)
            {
                // Check if there's such a word
                var sub = sb.ToString();

                if (dict.ContainsKey(sub))
                {
                    // Means the words has already been used
                    // Reset
                    if (dict[sub] == 0)
                    {
                        left = lastStart + 1;
                        right = left;
                        lastStart = left;

                        sb.Clear();

                        dict = copyDict.ToDictionary(e => e.Key, e => e.Value);
                        continue;
                    }
                    else
                    {
                        // It hasn't been used yet, which is good
                        if (right - lastStart + 1 == targetLength)
                        {
                            result.Add(lastStart);
                            left = lastStart + 1;
                            right = left;

                            lastStart = left;
                            sb.Clear();

                            dict = copyDict.ToDictionary(e => e.Key, e => e.Value);
                        }
                        else
                        {
                            dict[sub]--;
                            sb.Clear();
                            left = right + 1;
                            right = left;
                        }

                        continue;
                    }
                }
                else
                {
                    left = lastStart + 1;
                    lastStart = left;
                    right = left;
                    dict = copyDict.ToDictionary(e => e.Key, e => e.Value);
                    sb.Clear();
                    continue;
                }
            }

            right++;
        }

        return result;
    }
}
