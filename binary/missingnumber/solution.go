package main

import "fmt"

func main() {
	nums := []int{0, 1, 3}
	fmt.Println(missingNumber(nums))
}

func missingNumber(nums []int) int {
	var xor = 0
	for i := 0; i < len(nums); i++ {
		xor = xor ^ i ^ nums[i]
	}
	return xor ^ len(nums)
}
