package main

import "fmt"

//https://leetcode.com/problems/jump-game
func main() {
	nums := []int{3, 2, 1, 1, 4}
	r := canJump(nums)
	fmt.Println(r)
}

//Greedy Solution
func canJumpGreedy(nums []int) bool {

	canJump := true

	need := 1

	for i := len(nums) - 2; i >= 0; i-- {
		if nums[i] >= need {
			canJump = true
			need = 1
		} else {
			need++
			canJump = false
		}
	}

	return canJump
}

//Dynamic Programming Solution
func canJump(nums []int) bool {
	dp := make([]*int, len(nums))
	return helper(0, nums, dp)
}

func helper(current int, nums []int, dp []*int) bool {
	if current == len(nums)-1 {
		return true
	}

	var maxSteps = nums[current]
	if maxSteps == 0 {
		return false
	}

	for i := 1; i <= maxSteps; i++ {

		var stepTo = current + i
		if dp[stepTo] != nil {
			continue
		}

		r := helper(stepTo, nums, dp)

		if !r {
			dp[stepTo] = intp(0)
		}

		if r {
			return true
		}
	}

	return false
}

func intp(x int) *int {
	var val = x
	return &val
}
