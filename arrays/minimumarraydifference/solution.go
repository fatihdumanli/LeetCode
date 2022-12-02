package main

import (
	"fmt"
	"math"
)

//https://leetcode.com/problems/minimum-average-difference/
func main() {
	nums := []int{2, 5, 3, 9, 5, 3}
	fmt.Println(minimumAverageDifference(nums))
}

func minimumAverageDifference(nums []int) int {

	var n = len(nums)
	var prefix []int = make([]int, len(nums))
	var postfix []int = make([]int, len(nums)+1)

	var minAvg = math.MaxInt32
	var minAvgIndex = math.MaxInt32

	prefix[0] = nums[0]
	for i := 1; i < n; i++ {
		prefix[i] = prefix[i-1] + nums[i]
	}

	postfix[n-1] = nums[n-1]
	for i := n - 1; i >= 0; i-- {
		postfix[i] = postfix[i+1] + nums[i]
	}

	for i := 0; i < n; i++ {
		avgFirst := prefix[i] / (i + 1)
		avgLast := postfix[i+1] / Max((n-1-i), 1)

		absDiff := AbsInt(avgFirst - avgLast)

		if absDiff < minAvg {
			minAvg = absDiff
			minAvgIndex = i
		}

	}

	return minAvgIndex

}

func AbsInt(x int) int {
	if x < 0 {
		return -x
	}
	return x
}

func Max(a, b int) int {
	if a > b {
		return a
	}
	return b
}

func Min(a, b int) int {
	if a < b {
		return a
	}
	return b
}
