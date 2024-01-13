from typing import List
import sys

# https://leetcode.com/problems/maximum-subarray
class Solution:
    def maxSubArray(self, nums: List[int]) -> int:
        left = 0
        right = 0
        sum = 0
        result = -sys.maxsize - 1

        while right < len(nums):

            if sum < 0 and nums[right] >= sum:
                left = right
                sum = nums[right]
            else:
                sum += nums[right]

            result = max(result, sum)
            right += 1

        return result


obj = Solution()
nums = [-2, -5, 3, -4, 3, -1, 7]
r = obj.maxSubArray(nums)

print(r)
