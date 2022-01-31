package main

import (
	"fmt"
)

func main() {
	prices := []int{7, 1, 5, 3, 6, 4}
	result := maxProfit(prices)
	fmt.Println(result)
}

func maxProfit(prices []int) int {
	min := 1000000
	maxProfit := 0
	for _, p := range prices {
		min = getMin(min, p)
		maxProfit = getMax(maxProfit, p-min)
	}
	return maxProfit
}
func getMax(a, b int) int {
	if a > b {
		return a
	} else {
		return b
	}
}
func getMin(a, b int) int {
	if a < b {
		return a
	} else {
		return b
	}
}
