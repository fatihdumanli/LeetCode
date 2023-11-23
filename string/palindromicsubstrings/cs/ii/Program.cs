var s = "bb";// See https://aka.ms/new-console-template for more information
var r = CountSubstrings(s);
Console.WriteLine(r);


// https://leetcode.com/problems/palindromic-substrings/
int CountSubstrings(string s)
{
    var total = 0;

    for(int i = 0; i < s.Length; i++)
    {
        total += ExpandFromMiddle(s, i, i);
        total += ExpandFromMiddle(s, i, i + 1);
    }

    return total;
}

// Returns the number of iterations - total number of palindrome strings
int ExpandFromMiddle(string s, int left, int right)
{
    int iterations = 0;

    while(left >= 0 && right < s.Length && s[left] == s[right])
    {
        iterations++;
        left--;
        right++;
    }

    return iterations;
}
