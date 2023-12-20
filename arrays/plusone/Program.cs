namespace plusone;

class Program
{
    static void Main(string[] args)
    {
        var nums = new int[] { 9, 9, 9, 9 };

        var r = PlusOne(nums);

        Console.WriteLine("Hello world");
    }

    // https://leetcode.com/problems/plus-one/
    public static int[] PlusOne(int[] digits) 
    {
        var ptr = digits.Length - 1;

        for(int i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] < 9)
            {
                digits[i] = digits[i] + 1;

                return digits;
            }

            digits[i] = 0;
        }

        var newDigits = new int[digits.Length + 1];
        newDigits[0] = 1;

        return newDigits;
    }
}
