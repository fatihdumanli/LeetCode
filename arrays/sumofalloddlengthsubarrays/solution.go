package main

import "fmt"

//https://leetcode.com/problems/sum-of-all-odd-length-subarrays/
func main() {
	arr := []int{1,2}
	r := sumOddLengthSubarrays(arr)
	fmt.Println(r)
}

func sumOddLengthSubarrays(arr []int) int {

	presum := make([]int, len(arr)+1)

	sum := 0
	for i := 0; i < len(arr); i++ {
		sum += arr[i]
		presum[i+1] = sum
	}

	answer := 0

	maxLength := len(arr)
	if maxLength % 2 == 0 {
		maxLength -= 1
	}

	for i := 1; i <= maxLength; i = i + 2 {
		for j := i; j <= len(arr); j++ {
			answer += presum[j] - presum[j - i]
		}
	}

	return answer
}
