// See https://aka.ms/new-console-template for more information
var s = "cbbd";
var r = LongestPalindrome(s);

Console.WriteLine(r);

string LongestPalindrome(string s)
{
    string result = s[0].ToString();

    for(int i = 0; i < s.Length; i++)
    {
        var case1 = ExpandFromMiddle(s, i, i);
        var case2 = ExpandFromMiddle(s, i, i + 1);

        var longer = case1;

        if(case1.Item2 - case1.Item1 >= case2.Item2 - case2.Item1)
        {
            longer = case1;
        }
        else
        {
            longer = case2;
        }

        if(longer.Item2 - longer.Item1 + 1 > result.Length)
            result = s.Substring(longer.Item1, longer.Item2 - longer.Item1 + 1);
    }

    return result;
}


(int,int) ExpandFromMiddle(string s, int left, int right)
{
    while(left >= 0 && right < s.Length && s[left] == s[right])
    {
        left--;
        right++;
    }

    left++;
    right--;

    return (left, right);
}

