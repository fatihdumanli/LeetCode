package main

import (
	"fmt"
)

func main() {
	numbers := []int{0, 0, 1, 1, 1, 2, 2, 3, 3, 4}

	result := removeDuplicates(numbers)

	fmt.Println(result)
}

func removeDuplicates(nums []int) int {
	
	var k int

	if len(nums) == 0 {
		return 0
	}


	for i := len(nums) - 1; i > 0; i-- {

		if nums[i-1] == nums[i] {
			nums = shiftLeft(nums,i)
		}
	}
	
	for i := 0; i < len(nums) - 1; i++ {
		if nums[i] != nums[i+1] {
			k++	
		}	
	}

	return k + 1 

}

func shiftLeft(nums []int, start int) []int {

	for i := start; i < len(nums) - 1; i++ {
		nums[i] = nums[i + 1]
	}
	return nums
}
