namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var arr = new int[] { 1,2,34,3,4,5,7,23,12 };
        var r = ThreeConsecutiveOdds(arr);

        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/three-consecutive-odds
    static bool ThreeConsecutiveOdds(int[] arr)
    {
        if (arr.Length < 3)
            return false;

        var streak = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            var num = arr[i];

            if (num % 2 == 1)
            {
                streak++;
            }
            else
            {
                streak = 0;
            }

            if (streak == 3)
                return true;

        }

        return false;
    }
}
