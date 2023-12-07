using System.Text;

namespace cs;
class Program
{
    static void Main(string[] args)
    {
        var s = "43982741846728975348723564837564839647295642895642875";

        var r = LargestOddNumber(s);

        Console.WriteLine("result " + r);
        Console.Read();
    }

    // https://leetcode.com/problems/largest-odd-number-in-string/
    public static string LargestOddNumber(string num) 
    {
        for(int i = num.Length - 1; i >= 0; i--)
        {
            if(num[i] == '1' || num[i] == '3' || num[i] == '5' || num[i] == '7' || num[i] == '9')
                return num.Substring(0, i + 1); 
        }

        return "";
    }
}
