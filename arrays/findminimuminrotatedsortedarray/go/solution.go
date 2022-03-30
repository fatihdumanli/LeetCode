package main

import "fmt"

func main() {
	// 1, 2, 3, 4, 5
	nums := []int{2, 1}
	result := findMin(nums)
	fmt.Println(result)
}

func findMin(nums []int) int {
	min := nums[0]
	findMinHelper(nums, 0, len(nums)-1, &min)
	return min
}

func findMinHelper(nums []int, start int, end int, min *int) {
	if start > end {
		return
	}

	mid := (start + end) / 2

	if nums[start] <= nums[mid] {
		*min = Min(*min, nums[start])
		findMinHelper(nums, mid+1, end, min)
	} else {
		*min = Min(nums[mid], *min)
		findMinHelper(nums, start, mid-1, min)
	}
}

func Min(a, b int) int {
	if a < b {
		return a
	}
	return b
}
