namespace cs;

class Program
{
    static void Main(string[] args)
    {
        var price = new int[] { 1, 10, 20 };
        var r = MaximumTastiness(price, k: 3);

        Console.WriteLine(r);
    }

    // https://leetcode.com/problems/maximum-tastiness-of-candy-basket
    static int MaximumTastiness(int[] price, int k)
    {
        Array.Sort(price);

        var start = 0;
        var end = 1000000000;

        int mid = 0;
        var lastSatisfied = Int32.MinValue;

        while(start <= end)
        {
            mid = (start + end) / 2;

            if (DoesSatisfy(price, target: mid, k))
            {
                lastSatisfied = mid;
                start = mid + 1;
            }
            else
            {
                end = mid - 1;
            }
        }

        return lastSatisfied;
    }

    static bool DoesSatisfy(int[] price, int target, int k)
    {
        // Because we always take the first element
        k -= 1;

        var prev = 0;
        var ptr = 1;
        var ctr = 0;

        while (ptr < price.Length && ctr < k)
        {
            var diff = price[ptr] - price[prev];
            
            if (diff >= target)
            {
                ctr++;
                prev = ptr;
                ptr = prev + 1;
            }
            else
            {
                ptr++;
            }
        }

        return ctr >= k;
    }
}
