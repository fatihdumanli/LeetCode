from typing import List

# https://leetcode.com/problems/search-in-rotated-sorted-array
class Solution:
    def search(self, nums: List[int], target: int) -> int:
        return self.binarySearch(nums, 0, len(nums) - 1, target)

    def binarySearch(self, nums: List[int], start: int, end: int, target: int) -> int:
        if start > end:
            return -1

        mid = int((start + end) / 2)

        if nums[mid] == target:
            return mid

        if nums[start] <= nums[mid]: # left is sorted

            if self.isBetween(nums[start], nums[mid], target):
                return self.binarySearch(nums, start, mid, target)

            return self.binarySearch(nums, mid + 1, end, target)

        else: # right is sorted

            if self.isBetween(nums[mid], nums[end], target):
                return self.binarySearch(nums, mid, end, target)
            return self.binarySearch(nums, start, mid - 1, target)



    def isBetween(self, minimum: int, maximum: int, target: int) -> bool:
        return target >= minimum and target <= maximum


nums = [1, 3]

obj = Solution()
r = obj.search(nums, 2)

print(r)


