class Program
{
    static void Main(string[] args)
    {
        //[1,2,3,4,5,6,7,3,4,5,1,3,5,9,10,12,4,5,4,2]
        //var prices = new int[] { 1, 3, 4, 0, 6, 2 };
        //var prices = new int[] { 1, 6, 0, 9 };
        ///var prices = new int[] { 1, 2, 3, 4 };
        var prices = new int[] { 1, 5, 3, 2, 6 };
        var r = MaxProfit(prices);
        Console.WriteLine(r);
    }

    //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/
    static int MaxProfit(int[] prices)
    {
        var dp = new Dictionary<string, int>();
        var r = DFS(prices, 0, true, dp);
        return r;
    }

    static int DFS(int[] prices, int i, bool isBuying, Dictionary<string, int> dp)
    {
        if (i >= prices.Length)
            return 0;

        var key = $"{i}" + (isBuying ? "B" : "S");

        if (dp.ContainsKey(key))
            return dp[key];

        var cooldown = DFS(prices, i + 1, isBuying, dp);
        if (isBuying)
        {
            var buy = DFS(prices, i + 1, !isBuying, dp) - prices[i];
            dp[key] = Math.Max(buy, cooldown);
        }
        else
        {
            var sell = DFS(prices, i + 2, !isBuying, dp) + prices[i];
            dp[key] = Math.Max(sell, cooldown);
        }

        return dp[key];
    }
}

