package main

import "fmt"

func main() {
	nums := []int{1, 1, 3, 4, 5, 5, 5, 5, 5}
	target := 3
	r := searchRange(nums, target)
	fmt.Println(r)
}

func searchRange(nums []int, target int) []int {

	var start = -1
	var end = -1

	if len(nums) == 0 || !binarySearch(nums, 0, len(nums)-1, target) {
		return []int{-1, -1}
	}

	greatestSmallerElement := findGreatestSmallerElement(nums, 0, len(nums)-1, target)
	smallestGreaterElement := findSmallestGreaterElement(nums, 0, len(nums)-1, target)

	start = greatestSmallerElement
	end = smallestGreaterElement

	if start == 0 && nums[start] == target {
		start--
	}

	if end == len(nums)-1 && nums[end] == target {
		end++
	}

	return []int{start + 1, end - 1}
}

func binarySearch(arr []int, start int, end int, val int) bool {
	if start >= end {
		return arr[start] == val
	}

	var mid = start + (end-start)/2
	if arr[mid] == val {
		return true
	}

	if arr[mid] < val {
		return binarySearch(arr, mid+1, end, val)
	}

	return binarySearch(arr, start, mid, val)
}

func findSmallestGreaterElement(arr []int, start int, end int, val int) int {
	if end-start < 2 {
		if arr[start] > val {
			return start
		}
		return end
	}

	var mid = start + (end-start)/2

	if arr[mid] <= val {
		start = mid + 1
		// search right hand side
		return findSmallestGreaterElement(arr, start, end, val)
	}

	if arr[start] > val {
		return start
	}

	end = mid
	return findSmallestGreaterElement(arr, start, end, val)
}

func findGreatestSmallerElement(arr []int, start int, end int, val int) int {

	if end-start < 2 {
		if arr[end] < val {
			return end
		}
		return start
	}

	var mid = start + (end-start)/2

	if arr[mid] >= val {
		// the middle element is greater than target...
		// search the left hand side
		end = mid - 1
		return findGreatestSmallerElement(arr, start, end, val)
	}

	// the middle element is less than or equal to the target

	// if the greatest element is less than target, return it.
	if arr[end] < val {
		return end
	}

	// search the right hand side
	start = mid
	return findGreatestSmallerElement(arr, start, end, val)
}
