var s1 = "ab";
var s2 = "eidbaooo";
var result = CheckInclusion(s1, s2);
Console.WriteLine(result);

bool CheckInclusion(string s1, string s2) {
    int[] freq = new int[26];

    for(int i = 0; i < s1.Length; i++) {
        var ascii = s1[i] - 'a';
        freq[ascii]++;
    }

    var left = 0;
    var right = s1.Length - 1;

    while(right < s2.Length) {
        var substr = s2.Substring(left, right - left + 1);

        if(IsAnagram(freq.ToArray(), substr))
            return true;

        left++;
        right++;
    }

    return false;
}

bool IsAnagram(int[] freq, string s2) {

    for(int i = 0; i < s2.Length; i++) {
        var ascii = s2[i] - 'a';
        freq[ascii]--;
    }

    for(int i = 0; i < freq.Length; i++) {
        if(freq[i] != 0)
            return false;
    }
    return true;
}