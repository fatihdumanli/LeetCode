from typing import List

# https://leetcode.com/problems/container-with-most-water
class Solution:
    def maxArea(self, height: List[int]) -> int:

        left = 0
        right = len(height) - 1
        r = 0

        while left < right:
            w = right - left
            h = min(height[left], height[right])

            r = max(r, w * h)

            if height[left] <= height[right]:
                left += 1
            else:
                right -= 1

        return r



obj = Solution()
height = [1,2,1]

r = obj.maxArea(height)
print(r)
