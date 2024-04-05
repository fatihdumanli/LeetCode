using System.Text;
using System.Threading.Channels;

namespace cs;

class Program
{
    static void Main(string[] args)
    {
        // dabBADqeCcfFE
        // dabBADqemME
        // var s = "dabBADqeCcfFE";
        // 
        // var s = "abcdfFgGeED";
        //var s = "abcCBde";
        var s = "MqWWvyRtzZTrYVwwQmUjQOoOoqJu";
        var r = MakeGood(s);

        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/make-the-string-great
    public static string MakeGood(string s)
    {
        var sb = new StringBuilder(s);
        var isBad = true;

        while (isBad)
        {
            isBad = false;

            for (int i = 0; i < sb.Length - 1; i++)
            {
                var left = sb[i];
                var right = sb[i + 1];

                if (DoesMakeItBad(left, right))
                {
                    sb.Remove(i, 2);
                    isBad = true;
                    break;
                }
            }
        }
        return sb.ToString();
    }
    public static string MakeGood2(string s)
    {
        if (s.Length < 2)
            return s;

        const char CHAR_DELETED = '-';

        var charArray = s.ToArray();

        var left = 0;
        var right = 1;
        var startOfString = 0;

        while (right < s.Length)
        {
            var leftChar = charArray[left];
            var rightChar = charArray[right];

            if (!DoesMakeItBad(leftChar, rightChar))
            {
                left = right;
                right = left + 1;
                continue;
            }

            // Mark left and right as deleted
            charArray[left] = CHAR_DELETED;
            charArray[right] = CHAR_DELETED;

            // Check if the right at the most right (if we've reached to the end)
            if (right == s.Length - 1)
                break;

            // We'll remove both left and right
            // Check if we can pull left backwards
            if (left > startOfString)
            {
                while (left >= startOfString && charArray[left] == CHAR_DELETED)
                    left--;

                right++;
                continue;
            }

            // We cannot pull left back 
            // We need to check how many characters is there at the right handside
            // If there's only one character, we can exit the loop 
            // Because we need at least 2 characters to run another iteration
            if (right > s.Length - 2)
                break;

            // We can move left and right and reassing the startOFString
            left = right + 1;
            right = left + 1;
            startOfString = left;
        }

        var sb = new StringBuilder();

        foreach (var c in charArray)
        {
            if (c == CHAR_DELETED)
                continue;

            sb.Append(c);
        }

        return sb.ToString();
    }

    public static bool DoesMakeItBad(char left, char right)
    {
        // Return false if both are the same case
        if ((int)left >= 97 && (int)right >= 97)
            return false;

        if ((int)left < 97 && (int)right < 97)
            return false;

        // Check if they're equal
        left = (int)left >= 97 ? left : (char)((int)left + 32);
        right = (int)right >= 97 ? right : (char)((int)right + 32);

        return left == right;
    }
}
