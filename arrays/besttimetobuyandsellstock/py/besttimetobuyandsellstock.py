from typing import List

# https://leetcode.com/problems/best-time-to-buy-and-sell-stock
class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        minPrice = prices[0]
        maxProfit = 0

        for p in prices:
            minPrice = min(minPrice, p)
            maxProfit = max(maxProfit, p - minPrice)

        return maxProfit

sol = Solution()

prices = [7, 1, 5, 3, 6, 4]
r = sol.maxProfit(prices)
print(r)
