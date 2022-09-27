package main

import (
	"fmt"
	"math"
)

func main() {
	nums := []int{3, 2, 1, 5, 4, 5, 9, 2, 1}
	//nums := []int{2, 3, 1, 1, 4}
	r := jump(nums)
	fmt.Print(r)
}

func jump(nums []int) int {
	var dp = make([]int, len(nums))

	for i := 0; i < len(nums); i++ {
		dp[i] = math.MaxInt32
	}

	return helper(0, nums, dp)
}

//nums := []int{2, 3, 1, 1, 4}
func helper(current int, nums []int, dp []int) int {
	if current == len(nums)-1 {
		return 0
	}

	if current >= len(nums) {
		return math.MaxInt32
	}

	var max = nums[current]
	if max == 0 {
		return math.MaxInt32
	}

	for i := 1; i <= max; i++ {
		var stepTo = current + i

		if stepTo < len(nums) && dp[stepTo] != math.MaxInt32 {
			dp[current] = Min(dp[current], dp[stepTo]+1)
			continue
		}

		r := helper(stepTo, nums, dp)
		dp[current] = Min(dp[current], r+1)
	}

	return dp[current]
}

func Min(a, b int) int {
	if a < b {
		return a
	}
	return b
}
