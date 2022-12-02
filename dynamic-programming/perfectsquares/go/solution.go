package main

import (
	"fmt"
	"math"
)

//https://leetcode.com/problems/perfect-squares/
func main() {
	r := numSquares(100)
	//r := numSquares(7929)
	//r := numSquares(2)
	fmt.Println(r)
}

func numSquares(n int) int {

	var dp []int = make([]int, n+1)

	for i := 0; i <= n; i++ {
		dp[i] = math.MaxInt32
	}

	helper(0, n, &dp)

	return dp[0]
}

func helper(sum int, target int, dp *[]int) int {

	var min = math.MaxInt32

	for i := 1; i*i <= target; i++ {
		var num = i * i

		if sum+num == target {
			(*dp)[sum] = 1
			min = 0
		}

		if sum+num > target {
			return min
		}

		if (*dp)[sum+num] != math.MaxInt32 {
			(*dp)[sum] = Min((*dp)[sum], (*dp)[sum+num]+1)
			continue
		}

		r := helper(sum+num, target, dp)

		(*dp)[sum] = Min((*dp)[sum], r+1)
		min = Min(min, r)
	}

	return min + 1
}

func Min(a, b int) int {
	if a < b {
		return a
	}
	return b
}
