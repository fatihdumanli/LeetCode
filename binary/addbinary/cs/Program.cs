using System.Text;
using Microsoft.CSharp.RuntimeBinder;

namespace addbinary;

class Program
{
    static void Main(string[] args)
    {
        var a = args[0];
        var b = args[1];

        var r = AddBinary(a, b);
        Console.WriteLine(r);
    }

    public static char GetSum(char a, char b)
    {
        if (a == '0' && b == '0')
            return '0';
        if (a == '1' && b == '1')
            return '0';

        return '1';
    }
    // https://leetcode.com/problems/add-binary
    public static string AddBinary(string a, string b)
    {
        var aPtr = a.Length - 1;
        var bPtr = b.Length - 1;
        var carry = false;
        var sb = new StringBuilder();
        char aVal;
        char bVal;

        while (aPtr >= 0 || bPtr >= 0)
        {
            // We have values on both strings
            if (aPtr >= 0 && bPtr >= 0)
            {
                aVal = a[aPtr--];
                bVal = b[bPtr--];
            }
            else
            {
                // We have value in either of them (one of them)
                aVal = aPtr < 0 ? '0' : a[aPtr--];
                bVal = bPtr < 0 ? '0' : b[bPtr--];
            }

            if (aVal == '1' && bVal == '1')
            {
                // we already had carry
                if (carry)
                    sb.Append('1');
                else
                {
                    carry = true;
                    sb.Append('0');
                }
                continue;
            }
            var sum = GetSum(aVal, bVal);

            if (carry)
            {
                if (sum == '0')
                {
                    sum = '1';
                    carry = false;
                }
                else
                {
                    sum = '0';
                    carry = true;
                }
            }

            sb.Append(sum);
        }

        if (carry)
            sb.Append('1');

        var result = sb.ToString();
        var resultStr = result.ToString();
        var arr = resultStr.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}
