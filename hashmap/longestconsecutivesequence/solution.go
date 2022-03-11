package main

import (
	"fmt"
)

//https://leetcode.com/problems/longest-consecutive-sequence
func main() {
	var nums = []int{4, 0, -4, -2, 2, 5, 2, 0, -8, -8, -8, -8, -1, 7, 4, 5, 5, -4, 6, 6, -3}
	//	var nums = []int{}
	fmt.Println(longestConsecutive(nums))
}

func longestConsecutive(nums []int) int {
	if len(nums) == 0 {
		return 0
	}

	var max int = 1

	var hashset map[int]bool = make(map[int]bool)
	var initialElements []int

	for i := 0; i < len(nums); i++ {
		var num = nums[i]
		hashset[num] = true
	}

	for i := 0; i < len(nums); i++ {
		var num = nums[i]

		var left = num - 1
		if !hashset[left] {
			initialElements = append(initialElements, num)
		}
	}

	for i := 0; i < len(initialElements); i++ {

		var c = 1
		var right = initialElements[i] + 1

		for hashset[right] {
			c++
			right++
		}

		max = Max(max, c)
	}

	return max
}

func Max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
