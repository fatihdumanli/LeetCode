import sys
from typing import List

class Result:
    def __init__(self, value):
        self.value = value

# https://leetcode.com/problems/find-minimum-in-rotated-sorted-array
def findMin(nums: List[int]) -> int:

    r = Result(sys.maxsize)
    binarySearch(nums, 0, len(nums) - 1, r)

    return r.value

def binarySearch(nums: List[int], start: int, end: int, r: Result) -> int:

    if start > end:
        return -1

    mid = int((start + end) / 2)

    # the left part is fine (sorted)
    # and the least known value is nums[start]
    # 1. vet it by executing min(min, nums[start]
    # 2. search for lesser values on the right hand-side of the array
    if nums[start] <= nums[mid]:
        r.value = min(r.value, nums[start])
        return binarySearch(nums, mid + 1, end, r)
    # right handside is fine (sorted)
    # the min known value is nums[mid + 1]
    # 1. vet it by executing min(min, nums[mid + 1])
    # 2. search for lesser values on the left hand-side of the array
    else:
        r.value = min(r.value, nums[mid])
        return binarySearch(nums, start, mid - 1, r)

nums = [3, 1, 2]
r = findMin(nums)
print(r)



