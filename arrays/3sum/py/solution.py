import sys
from typing import List

# https://leetcode.com/problems/3sum/
def threeSum(nums: List[int]) -> List[List[int]]:
    nums.sort()

    result = []
    hashmap = {}

    for i in range(len(nums)):
        hashmap[nums[i]] = i

    for i in range(len(nums) - 2):

        if i > 0 and nums[i] == nums[i - 1]:
            continue

        leftVal = nums[i]
        ptr = i + 1
        rightVal = nums[ptr]

        while ptr < len(nums) - 1:
            rightVal = nums[ptr]
            sumVal = leftVal + rightVal
            seekFor = 0 - sumVal

            if hashmap.get(seekFor) != None and hashmap[seekFor] > ptr:
                result.append([leftVal, rightVal, seekFor])

            while ptr < len(nums) and nums[ptr] == rightVal:
                ptr += 1

    return result

nums = [-4, -1, -1, 0, 1, 2]

r = threeSum(nums)
print(r)
