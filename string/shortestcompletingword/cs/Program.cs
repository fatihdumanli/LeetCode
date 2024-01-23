namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var licencePlate = "GrC8950";
        var words = new string[] {"measure","other","every","base","according","level","meeting","none","marriage","rest"};

        var r = ShortestCompletingWord(licencePlate, words);

        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/shortest-completing-word
    public static string ShortestCompletingWord(string licensePlate, string[] words) 
    {
        var req = new int[26];

        foreach(var c in licensePlate)
        {
            var ascii = (int)c;
            // Check if non-alphanumeric
            if (!IsAlphanumeric(c))
                continue;

            // Check if it's uppercase
            if (ascii >= 65 && ascii <= 90)
                ascii += 32;

            req[ascii - 97]++;
        }

        var min = Int32.MaxValue;

        string result = string.Empty;

        foreach(var word in words)
        {
            if (!IsCompletingWord(req, word))
                continue;

            if (word.Length < min)
            {
                min = word.Length;
                result = word;
            }
        }


        return result;
    }

    static bool IsAlphanumeric(char c)
    {
        return (c >= 97 && c <= 122) || (c >= 65 && c <= 90);
    }

    static bool IsCompletingWord(int[] req, string word)
    {
        var freq = new int[26];
        
        foreach(var c in word)
            freq[c - 'a']++;

        for (int i = 0; i < freq.Length; i++)
        {
            if (req[i] > 0 && req[i] != freq[i])
                return false;
        }

        return true;
    }
}
