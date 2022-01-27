package main

import (
	"fmt"
)

func main() {

	nums := []int{2, 2, 1}

	result := singleNumber(nums)

	fmt.Println(result)

}

func singleNumber(nums []int) int {

	hashmap := make(map[int]int)

	for i := 0; i < len(nums); i++ {
		if hashmap[nums[i]] == 0 {
			hashmap[nums[i]] = 1
		} else {
			hashmap[nums[i]]++
		}

	}

	for i := 0; i < len(nums); i++ {

		if hashmap[nums[i]] == 1 {
			return nums[i]
		}
	}
	return 0
}
