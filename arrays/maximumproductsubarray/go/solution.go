package main

import "fmt"

func main() {
	//	nums := []int{2, 3, -2, 4}
	nums := []int{2, 3, -2, 4, -1, 5}
	res := maxProduct(nums)
	fmt.Println(res)
}

//  -4, 3, 2, -5, 8
//  2, 3, -2, 8
//  -1, 0, -3
//  2,  3,  -2,  4, -1, 5
func maxProduct(nums []int) int {

	if len(nums) == 1 {
		return nums[0]
	}

	min, max := 1, 1

	result := nums[0]
	for _, item := range nums {
		tmpMin := min
		min = Min(Min(item, item*min), item*max)
		max = Max(Max(item, item*max), tmpMin*item)
		result = Max(result, max)
	}

	return result
}

func Min(a, b int) int {
	if a < b {
		return a
	}
	return b
}

func Max(a, b int) int {

	if a > b {
		return a
	}
	return b
}
