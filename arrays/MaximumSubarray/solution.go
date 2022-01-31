package main

import "fmt"

func main() {
	nums := []int{-2, 1, -3, 4, -1, 2, 1, -5, 4}
	res := maxSubArray(nums)
	fmt.Println(res)
}

func maxSubArray(nums []int) int {
	max := -100000

	sum := 0

	for _, item := range nums {
		sum += item
		if item > sum {
			sum = item
		}

		if sum > max {
			max = sum
		}
	}
	return max
}
