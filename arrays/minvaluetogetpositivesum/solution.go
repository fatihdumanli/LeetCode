package main

import (
	"fmt"
)

func main() {
	nums := []int{1, 2}
	r := minStartValue(nums)
	fmt.Println(r)
}

func minStartValue(nums []int) int {
	cumSum := 0
	min := 0

	for i := 0; i < len(nums); i++ {
		cumSum += nums[i]
		min = Min(min, cumSum)
	}

	return -(min) + 1
}

func Min(a, b int) int {
	if a < b {
		return a
	}
	return b
}
