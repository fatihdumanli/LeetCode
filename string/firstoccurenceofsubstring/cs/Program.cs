// See https://aka.ms/new-console-template for more information

var haystack = "mississippi";
var needle = "issip";

var r = StrStr(haystack, needle);

Console.WriteLine(r);

//https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string
static int StrStr(string haystack, string needle)
{
    // Optimized brute-force solution
    for(int i = 0; i < haystack.Length; i++)
    {
        if(haystack[i] == needle[0])
        {
            var needlePtr = 0;
            var haystackPtr = i;

            while(haystackPtr <= haystack.Length - 1 && needlePtr <= needle.Length - 1 && haystack[haystackPtr] == needle[needlePtr])
            {
                needlePtr++;
                haystackPtr++;
            }
            
            if(needlePtr == needle.Length)
                return haystackPtr - needle.Length;
        }
    }
    
    return -1;
}
