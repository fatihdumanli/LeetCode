package main

import "fmt"

func main() {
	nums := []int{1, 2, 3, 1}
	res := containsDuplicate(nums)
	//should print true. since at least one element appears twice.
	fmt.Println(res)
}

func containsDuplicate(nums []int) bool {

	hashset := make(map[int]bool)

	for _, elm := range nums {
		if hashset[elm] {
			return true
		}
		hashset[elm] = true
	}
	return false
}
