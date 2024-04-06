namespace cs;

class Result
{
    public int val { get; set; }
    public int minDiff { get; set; } = Int32.MaxValue;
}
class Program
{
    static void Main(string[] args)
    {
        var x = 214739;

        var r = Sqrt(x);
    }

    // https://leetcode.com/problems/sqrtx
    static int Sqrt(int x)
    {
        // Starting from 0, we need to evaluate num * num 
        // As long as (num * num) is less than x
        long minDiff = Int32.MaxValue;
        long val = -1;

        long start = 0;
        long end = x;

        while (start <= end)
        {
            var mid = start + (end - start) / 2;

            if (mid * mid >= x)
            {
                var diff = Math.Abs(mid * mid - x);

                if (diff < minDiff)
                {
                    minDiff = diff;
                    val = mid;
                }

                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }

        if (val * val == x)
            return (int)val;

        return (int)val - 1;
    }
}
