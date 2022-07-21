var s = "tact coa";
var result = PalindromePermutation(s);

bool PalindromePermutation(string s)
{
    // Note: ignore non-letter characters
    var freq = new Dictionary<char, int>();

    for(int i = 0; i < s.Length; i++)
    {
        var cur = s[i];

        if(!IsLetter(cur))
            continue;
        
        if(freq.ContainsKey(cur))
        {
            freq[cur]++;
        }
        else
        {
            freq.Add(cur, 1);
        }
    }


    var oddOccurences = 0;

    foreach(var pair in freq)
    {
        if(pair.Value % 2 == 1)
            oddOccurences++;
    }

    return oddOccurences <= 1;
}


bool IsLetter(char c) => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');