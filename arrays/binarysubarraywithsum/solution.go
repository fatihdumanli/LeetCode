package main

import "fmt"

//https://leetcode.com/problems/binary-subarrays-with-sum/
func main() {
	nums := []int{1, 0, 1, 0, 1}
	goal := 2
	r := numSubarraysWithSum(nums, goal)
	fmt.Println(r)
}

func numSubarraysWithSum(nums []int, goal int) int {
	var result, presum = 0, 0
	var hashmap map[int]int = make(map[int]int)

	// the idea here is to find a pair [i,j] where i < j and sum[i:j] = goal

	// fact : sum[i:j] = prefix[j] - prefix[i - 1]

	// ALGEBRA
	// goal = presum[j] - presum[i - 1]
	// presum[i - 1] = presum[j] - goal

	// ✅ we know what presum[j] is, ✅ we know what goal is, the only thing for us to find out is,
	// how many i's are there that satisfies the condition (sum[i:j] = goal)
	// since there could be more tha n one i, we're gonna keep track of presums in a hashmap,
	// with the key of presum, and t he value of frequency.
	for i := 0; i < len(nums); i++ {
		presum += nums[i]

		searchFor := presum - goal
		if v, ok := hashmap[searchFor]; ok {
			result += v
		}

		if _, ok := hashmap[presum]; ok {
			hashmap[presum]++
		} else {
			hashmap[presum] = 1
		}

		if presum == goal {
			result++
		}
	}

	return result
}
