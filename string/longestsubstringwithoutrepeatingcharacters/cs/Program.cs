var s = "tmmzuxt";
var result = LengthOfLongestSubstring(s);
Console.WriteLine(result);

int LengthOfLongestSubstring(string s)
{
    if(s.Length == 0) {
        return 0;
    }

    if(s.Length == 1) {
        return 1;
    }

    var maxLength = 1;
    var hashmap = new Dictionary<char, int>();
    var left = 0;
    var right = 1;
    hashmap.Add(s[left], left);


    while(left <= right && right <= s.Length - 1) 
    {
        if(!hashmap.ContainsKey(s[right])) 
        {
            hashmap.Add(s[right], right);
            maxLength = Math.Max(maxLength, right - left + 1);
            right++;
        } else {
            hashmap.Remove(s[left]);
            left++;
        }
    }

    return maxLength;
}