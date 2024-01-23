namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var palindrome = "aabdbaa";
        var r = BreakPalindrome(palindrome);

        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/break-a-palindrome
    public static string BreakPalindrome(string palindrome) 
    {
        if (palindrome.Length == 1)
            return string.Empty;

        var arr = palindrome.ToCharArray();

        var left = 0;
        var right = palindrome.Length - 1;

        Func<char, bool> CanDecrease = (c) => c > 97;

        // If we pass the first half of the string,
        // We don't need to find the correspoing pointer.
        // Just head ahead to the last character and increase/decrease the 
        // Last character by 1.
        while (left < right)
        {
            if (!CanDecrease(arr[left]))
            {
                left++;
                right--;
                continue;
            }

            else
            {
                // We can decrease the left pointer
                // So we start from 'a'
                // And keep going as long as s[left] == s[right]
                arr[left] = 'a';

                while (arr[left] == arr[right])
                {
                    arr[left] = (char)((int)arr[left] + 1);
                }

                return new string(arr);
            }
        }

        // First half didn't work out 
        // "aaadaaa"
        // That's only possible if the first half of the string consists of 'a'
        // Because if we were able to get any character other than "a" in the
        // first half of the string, we would've just decrease it to smallest
        // possible character and we would've gotten the lexicographically
        // smallest answer.
        //
        // So we had down to the end of the string and increase it by 1.
        // In order to get lexicographically smallest possible answer.
        arr[arr.Length - 1] = (char) ((int) arr[arr.Length - 1] + 1);


        return new string(arr);
    }
}
