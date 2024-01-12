from typing import List

# https://leetcode.com/problems/contains-duplicate
class Solution:
    def containsDuplicate(self, nums: List[int]) -> bool:

        hashset = set()

        for n in nums:
            if n in hashset:
                return True

            hashset.add(n)

        return False

obj = Solution()

nums = [1, 2, 3]
r = obj.containsDuplicate(nums)
print(r)

