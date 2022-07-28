package main

import (
	"fmt"
	"math"
)

func main() {
	prices := []int{1, 2, 3, 4, 5}
	r := maxProfit(prices)
	fmt.Println(r)
}

func maxProfit(prices []int) int {
	var maxProfit int
	var holding = true
	var lastBoughtPrice = prices[0]

	var getNextDayPrice = func(i int) int {
		// if it's last element, no matter what we need to sell it, so that return -2^31 + 1
		if i == len(prices)-1 {
			return math.MinInt32
		} else {
			return prices[i+1]
		}
	}
	for i := 1; i < len(prices); i++ {

		if !holding {
			holding = true
			lastBoughtPrice = prices[i]
		} else if holding && prices[i]-lastBoughtPrice > 0 && getNextDayPrice(i) < prices[i] {
			holding = false
			maxProfit += prices[i] - lastBoughtPrice
		} else if holding && prices[i] < lastBoughtPrice {
			lastBoughtPrice = prices[i]
		}
	}

	return maxProfit
}
