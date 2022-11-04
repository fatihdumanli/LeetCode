package main

import "fmt"

//https://leetcode.com/problems/number-of-good-pairs/
func main() {
	nums := []int{1,2,3,1,1,3}
	r := numIdenticalPairs(nums)
	fmt.Println(r)
}

func numIdenticalPairs(nums []int) int {
	var hashmap map[int]int = make(map[int]int, len(nums))
	answer := 0

	for i := 0; i < len(nums); i++ {
		if v, ok := hashmap[nums[i]]; ok {
			answer += v
			hashmap[nums[i]]++
		} else {
			hashmap[nums[i]] = 1
		}
	}

	return answer
}