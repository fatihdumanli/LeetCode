package main

import (
	"fmt"
	"sort"
)

func main() {
	//var nums = []int{-1, 0, 1, 2, -1, -4}
	var nums = []int{0, 0, 0, 0}
	r := threeSum(nums)
	fmt.Println(r)
}

// Return all the triplets [ [nums[i], nums[j], nums[k] ] such that,
// i != j,  i != k, j != k and nums[i] + nums[j] + nums[k] == 0
func threeSum(nums []int) [][]int {
	sort.Slice(nums, func(i int, j int) bool {
		return nums[j] > nums[i]
	})

	var result [][]int

	// There can't be such triplet
	if nums[0] > 0 {
		return result
	}

	for i := 0; i < len(nums); i++ {

		if i > 0 && nums[i] == nums[i-1] {
			continue
		}

		var left = i + 1
		var right = len(nums) - 1

		for left < right {
			sum := nums[i] + nums[left] + nums[right]
			if sum < 0 {
				var temp = nums[left]

				for nums[left] == temp && left < right {
					left++
				}

			} else if sum > 0 {
				var temp = nums[right]

				for nums[right] == temp {
					right--
				}
			} else if sum == 0 {
				result = append(result, []int{nums[i], nums[left], nums[right]})

				var temp = nums[left]

				for temp == nums[left] && left < right {
					left++
				}
			}
		}

	}

	return result
}
