package main

import (
	"fmt"
	"sort"
)

func main() {
	nums := []int{-1, 0, 1, 2, -1, -4}
	res := threeSum(nums)
	fmt.Println(res)
}

func threeSum(nums []int) [][]int {
	var result [][]int

	// 2, -1, 1
	// 2, 0, -2
	//  -4, -1, -1, 0, 1, 2
	//  -4, -3, -1, -1, 0, 1, -2, 3, 4
	sort.Ints(nums)

	for i := 0; i < len(nums)-2; i++ {

		if i > 0 && nums[i] == nums[i-1] {
			continue
		}

		left := i + 1
		right := len(nums) - 1

		currentValue := nums[i]

		for left < right {

			leftValue := nums[left]
			rightValue := nums[right]

			sum := currentValue + leftValue + rightValue

			if sum > 0 {
				right--
			} else if sum < 0 {
				left++
			} else {

				result = append(result, []int{currentValue, leftValue, rightValue})
				for left < right && nums[left] == nums[left+1] {
					left++
				}
				for left < right && nums[right] == nums[right-1] {
					right--
				}
				left++
				right--
			}
		}
	}

	return result
}
