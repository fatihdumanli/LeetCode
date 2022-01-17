package main

import "fmt"

func main() {
	nums := []int{4, 5, 6, 7, 0, 1, 2}
	res := search(nums, 3)
	fmt.Println(res)
}

func search(nums []int, target int) int {
	return searchHelper(nums, 0, len(nums)-1, target)
}

func searchHelper(nums []int, start int, end int, target int) int {
	if start > end {
		return -1
	}

	mid := (start + end) / 2

	if nums[mid] == target {
		return mid
	}
	//left hand side is sorted
	if nums[start] <= nums[mid] {
		if nums[start] <= target && nums[mid] >= target {
			return searchHelper(nums, 0, mid-1, target)
		} else {
			return searchHelper(nums, mid+1, end, target)
		}
	} else {

		if nums[mid] <= target && nums[end] >= target {
			return searchHelper(nums, mid+1, end, target)
		} else {
			return searchHelper(nums, 0, mid-1, target)
		}
	}
	return -1

}
