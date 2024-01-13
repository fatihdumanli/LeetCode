import sys
from typing import List

# https://leetcode.com/problems/maximum-product-subarray
class Solution:
    def maxProduct(self, nums: List[int]) -> int:
        neg = 1
        pos = 1
        result = -sys.maxsize - 1

        for i in range(len(nums)):

            if nums[i] > 0:
                result = max(result, pos * nums[i])
                pos = max(pos, pos * nums[i], nums[i])
                neg = min(neg * nums[i], neg)
            elif nums[i] < 0:
                result = max(result, neg * nums[i])
                temp = pos
                pos = max(1, neg * nums[i])
                neg = min(temp * nums[i], 1, nums[i])
            elif nums[i] == 0:
                result = max(result, 0)
                pos = 1
                neg = 1

        return result


# nums = [2,3,0,4,2]
# nums = [2,3,-2,4,2,-1,2, -4]
# nums = [-2, 2, 4, -1, 3, 2 ]
nums = [2, -5, -2, -4, 3]

obj = Solution()
r = obj.maxProduct(nums)

print(r)

