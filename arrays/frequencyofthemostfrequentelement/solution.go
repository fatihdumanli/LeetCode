package main

import (
	"fmt"
	"sort"
)

//https://leetcode.com/problems/frequency-of-the-most-frequent-element/
func main() {
	nums := []int{1,1,2,3,4,4,5,5,5,5,6,6,7}
	k := 5
	r := maxFrequency(nums, k)
	fmt.Println(r)
}

func maxFrequency(nums []int, k int) int {

	if len(nums) == 1 {
		return 1
	}

	sort.Ints(nums)

	var max = 1

	j := len(nums) - 2
	for i := len(nums) - 1; i > 0 && j >= 0; i-- {
		if nums[i] - nums[j] > k {
			if i > 0 {
				k += (i - j - 1) *  (nums[i] - nums[i - 1])
			}
			continue
		}

		//we should always end up with a valid window
		for ;j >= 0; j-- {
			if k - (nums[i] - nums[j]) < 0 {
				break
			}

			k -= nums[i] - nums[j]
		}
		max = Max(max, i - j)

		k += (i - j - 1) *  (nums[i] - nums[i - 1])
	}

	return max
}

func Max(a, b int) int {
	if a > b {
		return a
	}
	return b
}