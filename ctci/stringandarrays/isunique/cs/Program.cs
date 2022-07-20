string s = "rotterdam";
Console.WriteLine(IsUnique(s));

// Return true if the string consists of unique characters.
bool IsUnique(string s)
{
    if (s.Length > 128) 
        return false;

    bool[] freq = new bool[128];

    for(int i = 0; i < s.Length; i++)
    {
        char c = s[i];

        if(freq[c])
            return false;
        
        freq[c] = true;
    }

    return true;
}