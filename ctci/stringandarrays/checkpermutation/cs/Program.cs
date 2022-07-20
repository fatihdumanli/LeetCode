var s1 = "fate";
var s2 = "atel";

var result = IsPermutation(s1, s2);
Console.WriteLine(result);


// Given two strings, write a method to decide if one string is permutation of the other.
// Assumption: Both strings consist of ASCII characters
bool IsPermutation(string s1, string s2)
{
    if(s1.Length != s2.Length)
        return false;

    int[] freq = new int[128];

    for(int i = 0; i < s1.Length; i++)
    {
        var idx = s1[i];
        freq[idx]++;

        var idx2 = s2[i];
        freq[idx2]--;
    }

    for(int i = 0; i < 128; i++)
    {
        if(freq[i] != 0)
            return false;
    }


    return true;
}

