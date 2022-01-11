using System;
using System.Collections.Generic;

namespace BestTimeToBuyAndSellStockWithTransactionFee
{
    class Program
    {
        static void Main(string[] args)
        {
            var prices = new int[] { 2,3,1,8,4,9};
            var fee = 2;

            var result = MaxProfit(prices, fee);
            Console.WriteLine("Hello World!");
        }

        static int MaxProfit(int[] prices, int fee)
        { 
            int boughtAt = prices[0];
            int minPrice = boughtAt;
            int profit = 0;
            
            for (int i = 1; i < prices.Length - 1; i++)
            {
                minPrice = Math.Min(minPrice, prices[i]);
                
                if(prices[i] > boughtAt + fee && prices[i + 1] < prices[i])
                {
                    profit += prices[i] - boughtAt - fee;
                    //check if we hadn't sell
                    
                    if(prices[i] - minPrice - fee > profit)
                        profit = prices[i] - minPrice - fee;
                    
                    boughtAt = prices[i + 1];
                    continue;
                }
                    
                if(prices[i] < boughtAt)
                    boughtAt = prices[i];
            }
        
    
            
            if(prices[prices.Length - 1] > boughtAt + fee)
            {
                profit += prices[prices.Length - 1] - boughtAt - fee;
                
                if(prices[prices.Length - 1] - minPrice - fee > profit)
                    profit = prices[prices.Length - 1] - minPrice - fee;
            }
                
            return profit;    
        }
        
    }
}
