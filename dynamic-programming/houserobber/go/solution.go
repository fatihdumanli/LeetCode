package main

import "fmt"

//https://leetcode.com/problems/house-robber/
func main() {
	var houses = []int{2, 7, 9, 3, 1, 4, 5, 6, 7}
	var res = rob(houses)
	fmt.Println(res)
}

func rob(nums []int) int {
	var dp []*int = make([]*int, 100)
	return helper(nums, 0, dp)
}

func helper(nums []int, from int, dp []*int) int {
	if from > len(nums)-1 {
		return 0
	}
	if from == len(nums)-1 {
		return nums[len(nums)-1]
	}
	if dp[from] != nil {

		return *(dp[from])
	}
	res := Max(nums[from]+helper(nums, from+2, dp), nums[from+1]+helper(nums, from+3, dp))
	dp[from] = intp(res)
	return res
}

func intp(x int) *int {
	return &x
}

func Max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
