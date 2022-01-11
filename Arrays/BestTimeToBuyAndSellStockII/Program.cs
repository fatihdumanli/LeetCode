using System;

namespace BestTimeToBuyAndSellStockII
{
    class Program
    {
        static void Main(string[] args)
        {
            var prices = new int[] { 7,1,5,3,6,4};
            var maxProfit = MaxProfit(prices); 
            Console.WriteLine("Hello World!");
        }
        
        public static int MaxProfit(int[] prices)
        {
            int boughtAt = Int32.MaxValue;
            int profit = 0;
            
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < boughtAt)
                {
                    boughtAt = prices[i];
                    continue;
                }

                
                if (i == prices.Length - 1)
                {
                    if (prices[i] > boughtAt)
                        profit += prices[i] - boughtAt;
                    break;
                }
                
                if (prices[i] > prices[i + 1])
                {
                    profit = prices[i] - boughtAt;
                    boughtAt = Int32.MaxValue;
                }

            }
            

            return profit;
        }
    }
}
