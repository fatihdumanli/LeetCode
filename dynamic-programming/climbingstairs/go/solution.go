package main

import "fmt"

func main() {
	fmt.Println(climbStairs(4))
}

func climbStairs(n int) int {
	var dp []int = make([]int, n+1)
	dp[0] = 1
	dp[1] = 1

	for i := 2; i <= n; i++ {
		dp[i] = dp[i-1] + dp[i-2]
	}

	return dp[n]
}
