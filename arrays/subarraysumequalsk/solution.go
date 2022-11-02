package main

import "fmt"

//https://leetcode.com/problems/subarray-sum-equals-k/
func main() {
	nums := []int{-1,-1,1}
	k := 0
	r := subarraySum(nums, k)
	fmt.Println(r)
}

func subarraySum(nums []int, k int) int {
	var answer = 0
	var hashmap map[int]int = make(map[int]int)
	var presum []int = make([]int, len(nums))

	presum[0] = nums[0]
	hashmap[presum[0]] = 1

	if presum[0] == k {
		answer += 1
	}

	for i := 1; i < len(nums); i++ {
		presum[i] = presum[i - 1] + nums[i]
		key := presum[i] - k

	    if v, ok := hashmap[key]; ok {
	    	answer += v
	    }

		if _, ok := hashmap[presum[i]]; ok {
			hashmap[presum[i]]++
		} else {
			hashmap[presum[i]] = 1
		}

		if presum[i] == k {
			answer++
		}
	}
	return answer
}