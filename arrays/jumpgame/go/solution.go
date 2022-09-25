package main

import "fmt"

func main() {
	//nums := []int{3, 2, 1, 0, 4}
	nums := []int{2, 3, 1, 1, 4}
	r := canJump(nums)
	fmt.Println(r)
}
func intp(x int) *int {
	var val = x
	return &val
}

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
