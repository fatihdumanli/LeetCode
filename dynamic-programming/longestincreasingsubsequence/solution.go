package main

import (
	"fmt"
)

func main() {
	var nums []int = []int{0, 1, 0, 2, 5, 3, 7, 18}
	//	var nums []int = []int{7, 4, 8}
	fmt.Println(lengthOfLIS(nums))
}

func lengthOfLIS(nums []int) int {
	var max int
	var dp []int = make([]int, len(nums))

	for i := 0; i < len(nums); i++ {
		seq, _ := helper(nums, i, dp)
		max = Max(max, seq)
	}
	return max
}

func helper(nums []int, index int, dp []int) (int, int) {
	if index == len(nums)-1 {
		return 1, nums[index]
	}

	var max int = 1
	for i := index + 1; i < len(nums); i++ {

		if nums[i] <= nums[index] {
			continue
		}

		var seq, val int

		if dp[i] != 0 {
			seq = dp[i]
			val = nums[i]
		} else {
			seq, val = helper(nums, i, dp)
		}

		if nums[index] < val {
			max = Max(max, seq+1)
		}
		dp[i] = Max(dp[i], seq)
	}

	return max, nums[index]

}

func Max(a, b int) int {
	if a > b {
		return a
	}
	return b
}

func intp(x int) *int {
	return &x
}
