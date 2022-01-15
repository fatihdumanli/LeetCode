package main

import "fmt"

func main() {

	nums := []int{3, 2, 4}
	res := twoSum(nums, 6)
	fmt.Println(res)
}

func twoSum(nums []int, target int) []int {

	var hashmap map[int]int
	hashmap = make(map[int]int, len(nums))

	for i, n := range nums {
		diff := target - n

		if idx, isExist := hashmap[diff]; isExist {
			return []int{idx, i}
		} else {
			hashmap[n] = i
		}
	}

	return nil
}
