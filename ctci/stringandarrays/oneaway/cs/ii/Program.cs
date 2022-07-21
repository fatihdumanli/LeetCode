var s1 = "pale";
var s2 = "bake";
var result = OneAway(s1, s2);
Console.WriteLine(result);


bool OneAway(string s1, string s2)
{
    if(Math.Abs(s1.Length - s2.Length) > 1) {
        return false;
    }

    // If the length of the two strings are equal
    // There's gotta be at most 1 mismatch between the characters
    if(s1.Length == s2.Length) {
        bool mismatch = false;

        for(int i = 0; i < s1.Length; i++)
        {
            if(s1[i] == s2[i]) continue;
            if(mismatch)
                return false;
            mismatch = true;
        }
    } else {
        // Insert or remove
        var freq1 = new char[26];
        for(int i = 0; i < s1.Length; i++)
        {
            var c = s1[i];
            freq1[c - 'a']++;
        }


        var freq2 = new char[26];
        for(int i = 0; i < s2.Length; i++)
        {
            var c = s2[i];
            freq2[c - 'a']++;
        }


        bool mismatch = false;
        for(int i = 0; i < 26; i++)
        {
            if(freq1[i] == freq2[i]) continue;
            if(mismatch)
                return false;
            mismatch = true;
        }
    }

    return true;
}
