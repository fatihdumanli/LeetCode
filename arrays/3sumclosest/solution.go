package main

import (
	"fmt"
	"math"
	"sort"
)

func main() {
	nums := []int{-1, 2, 1, -4}
	r := threeSumClosest(nums, 1)
	fmt.Println(r)
}

func threeSumClosest(nums []int, target int) int {

	var minDiff = math.MaxInt32
	var answer = math.MaxInt32

	sort.Slice(nums, func(i, j int) bool {
		if nums[i] < nums[j] {
			return true
		}
		return false
	})

	for i := 0; i < len(nums)-2; i++ {
		var second = i + 1
		var third = len(nums) - 1

		for second < third {
			var sum = nums[i] + nums[second] + nums[third]

			var diff = Abs(target - sum)

			if diff < minDiff {
				answer = sum
				minDiff = diff
			}

			if sum < target {
				second++
			} else if sum > target {
				third--
			} else {
				return sum
			}
		}
	}

	return answer
}

func Abs(x int) int {
	if x < 0 {
		return -x
	}
	return x
}
