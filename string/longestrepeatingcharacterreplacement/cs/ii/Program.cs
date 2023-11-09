using Microsoft.VisualBasic;

namespace ii;
class Program
{
    static void Main(string[] args)
    {
        var s = "BAAAB";
        var k = 2;
        var r = CharacterReplacement(s, k);
        
        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/longest-repeating-character-replacement
    static int CharacterReplacement(string s, int k)
    {
        var freq = new int[26];
        var left = 0;
        var right = 0;
        var max = Int32.MinValue;
        
        while(right < s.Length)
        {
            freq[s[right] - 65]++;

            if(IsValidWindow(freq, right - left + 1, k))
            {
                max = Math.Max(max, right - left + 1);
                right++;
            }
            else
            {
                freq[s[left] - 65]--;
                
                // right will be visited twice and 
                // will be increased the frequency of extra. 
                // so we decrement here to make up for it
                freq[s[right] - 65]--;
                left++;
            }
        }
        
        return max;
    }
    
    static bool IsValidWindow(int[] freq, int length, int k)
    {
        var max = 0;

        for(int i = 0; i < freq.Length; i++)
        {
            if(freq[i] > max)
                max = freq[i];
        }
        
        if(length - max > k)
            return false;
        
        return true;
    }
}
