package main

import (
	"fmt"
	"math"
)

//https://leetcode.com/problems/coin-change/
func main() {
	coins := []int{419, 186, 83, 408}
	fmt.Println(coinChange(coins, 6249))
}
func coinChange(coins []int, amount int) int {

	var dp = make([]int, amount+1)
	dp[0] = 0
	for i := 1; i <= amount; i++ {
		dp[i] = math.MaxInt32
	}

	for i := 0; i <= amount; i++ {
		helper(i, coins, dp)
	}

	if dp[amount] == math.MaxInt32 {
		return -1
	}
	return dp[amount]

}

func helper(i int, coins []int, dp []int) {

	for _, c := range coins {
		if c > i {
			continue
		}

		if c == i {
			dp[i] = 1
		}

		var t = i - c
		if dp[t] != math.MaxInt32 {
			dp[i] = Min(dp[i], dp[t]+1)
		}
	}

}

func Min(a, b int) int {
	if a < b {
		return a
	} else {
		return b
	}
}
