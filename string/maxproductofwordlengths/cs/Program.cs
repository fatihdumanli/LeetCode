namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var words = new string[] { "abc", "def", "ab", "wfdsf" };
        var r = MaxProduct(words);

        Console.WriteLine("Hello, World!");
    }

    // This problem is all about modeling an integer as a frequency array.
    // Imagine the bits
    // 0000000000000000000000
    // The string 'abc' would result in the bits
    // 1110000000000000000000
    // If we happen to apply & operator 'def'
    // 1110000000000000000000
    // 0001111111111111111111
    // That would result in 0.
    // Which precisely means these two string does not have any common
    // characters.
    //
    // So we practically move the bit '1' for the number of times x,
    // Where x corresponds to the 'reverse' order of the letter in the English
    // alphabet.
    //
    // For 'a' we shift the bit '00000000000001' for 26 times which would result
    // in '100000000000000000000'
    // For 'b', we shift the bit '0000000000001' for 25 times which would result
    // in '010000000000000000000' 
    // And so on...
    // After getting all binary representations of the words, all we need to do
    // is that apply '&' operator between them to see if they share a common
    // char.
    //
    // If they don't, we evaluate result.
    // https://leetcode.com/problems/maximum-product-of-word-lengths
    static int MaxProduct(string[] words) {

        var wordBits = new long[words.Length];
        var r = 0;

        for (int i = 0; i < words.Length; i++)
        {
            wordBits[i] = GetBits(words[i]);
        }

        for(int i = 0; i < words.Length - 1; i++)
        {
            for (int j = 1; j < words.Length; j++)
            {
                if ((wordBits[i] & wordBits[j]) == 0)
                    r = Math.Max(r, words[i].Length * words[j].Length);
            }
        }

        return r;
    }

    static long GetBits(string word)
    {
        long num = 0;

        foreach(var c in word)
        {
            num |= 1 << 26 - (c - 97);
        }

        var r = num & num;

        return num;
    }

}
