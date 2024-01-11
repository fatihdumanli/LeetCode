#!/usr/bin/python3

from typing import List

class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:

        hashmap = {}

        for i in range(len(nums)):
            hashmap[nums[i]] = i

        for i in range(len(nums)):
            search = target - nums[i]

            if hashmap.get(search) is not None and hashmap.get(search) != i:
                return [i, hashmap[search]]

        return [-1,-1]


solution_instance = Solution()

nums = [3, 2, 4]
target = 6

result = solution_instance.twoSum(nums, target)

print(result)


