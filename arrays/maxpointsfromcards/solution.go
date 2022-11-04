package main

import (
	"fmt"
)

//https://leetcode.com/problems/maximum-points-you-can-obtain-from-cards/
func main() {
	cardPoints := []int{9,7,7,9,7,7,9}
	k := 6
	r := maxScore(cardPoints, k)
	fmt.Println(r)
}

func maxScore(cardPoints []int, k int) int {
	windowSize := len(cardPoints) - k
	left := 0
	right := left + windowSize - 1

	totalPoints := 0

	for i := 0; i < len(cardPoints); i++ {
		totalPoints += cardPoints[i]
	}

	if k == len(cardPoints) {
		return totalPoints
	}
	
	sum := 0
	for i := left; i <= right; i++ {
		sum += cardPoints[i]
	}
	min := sum
	for right < len(cardPoints) {
		sum -= cardPoints[left]
		left++
		right++

		if right >= len(cardPoints) {
			break
		}

		sum += cardPoints[right]
		min = Min(min, sum)
	}

	return totalPoints - min
}

func Min(a,b int) int {
	if a < b {
		return a
	}
	return b
}
