package main

import "fmt"

func main() {
	nums := []int{3}
	r := pivotIndex(nums)
	fmt.Println(r)
}

func pivotIndex(nums []int) int {
	var sum int

	for i := 0; i < len(nums); i++ {
		sum += nums[i]
	}

	var right int = sum
	sum = 0

	for i := 0; i < len(nums); i++ {
		right -= nums[i]

		if right == sum {
			return i
		}
		sum += nums[i]
	}

	return -1
}
