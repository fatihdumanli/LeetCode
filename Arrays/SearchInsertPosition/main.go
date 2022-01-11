package main

import (
	"fmt"
)

func main() {
	nums := []int{1, 3, 5, 6}
	result := searchInsert(nums, 2)
	fmt.Println(result)
}

func searchInsert(nums []int, target int) int {
	return binarySearch(nums, 0, len(nums), target)
}
func binarySearch(arr []int, start int, end int, target int) int {
	if start >= end {
		return -1
	}

	mid := (start + end) / 2

	if target == arr[mid] {
		return mid
	}

	if target < arr[mid] {
		return binarySearch(arr, start, mid, target)
	}
	if target > arr[mid] {
		return binarySearch(arr, mid+1, end, target)
	}

	return -1
}
