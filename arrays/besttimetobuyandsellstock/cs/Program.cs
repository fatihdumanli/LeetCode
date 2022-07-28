//https://leetcode.com/problems/best-time-to-buy-and-sell-stock/

var prices = new int[] { 7, 1, 5, 3, 6, 4 };
var result = MaxProfit(prices);
Console.WriteLine(result);

int MaxProfit(int[] prices)
{
    var minSoFar = prices[0];
    var maxProfit = 0;

    for(int i = 0; i < prices.Length; i++)
    {
        maxProfit = Math.Max(maxProfit, prices[i] - minSoFar);
        minSoFar = Math.Min(minSoFar, prices[i]);
    }
    return maxProfit;
}
