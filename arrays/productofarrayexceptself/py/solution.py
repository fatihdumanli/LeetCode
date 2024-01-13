from typing import List

# https://leetcode.com/problems/product-of-array-except-self
class Solution:
    def productExceptSelf(self, nums: List[int]) -> List[int]:
        result = [0] * len(nums)

        result[0] = 1
        ptr = 0
        product = 1

        for i in range(1, len(nums)):
            product *= nums[ptr]
            result[i] = product
            ptr += 1

        product = 1
        ptr = len(nums) - 1

        for i in range(len(nums) - 2, -1, -1):
            product *= nums[ptr]
            result[i] = result[i] * product
            ptr -= 1

        return result


nums = [1, 2]

obj = Solution()
r = obj.productExceptSelf(nums)
print(r)

