package main

import "fmt"

func main() {
	//	nums := []int{2, 3, -2, 4}
	nums := []int{-1, 0, -3}
	res := maxProduct(nums)
	fmt.Println(res)
}

//  -4, 3, 2, -5, 8
//  2, 3, -2, 8
//  -1, 0, -3
//  2,  3,  -2,  4, -1, 5

func maxProduct(nums []int) int {

	/*
		//min	max
		1	2
		1	6

	*/
	result := nums[0]
	min, max := 1, 1

	product := 1
	for _, elm := range nums {
		product *= elm
		tmpMin := min
		min = Min(Min(min, min*elm), max*elm)
		max = Max(Max(max, product), tmpMin*elm)
	}

	result = max
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
