package main

import "fmt"

func main() {

	nums := []int{1, 2, 3, 4}

	res := productExceptSelf(nums)
	fmt.Println(res)
}

func productExceptSelf(nums []int) []int {

	product := 1

	result := make([]int, len(nums))

	for i, item := range nums {
		result[i] = product
		product *= item
	}

	product = nums[len(nums)-1]

	for i := len(nums) - 2; i >= 0; i-- {
		result[i] *= product
		product *= nums[i]
	}

	return result
}
