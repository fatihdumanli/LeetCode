package main

import "fmt"

func main() {

	var s = "AABABBA"
	k := 1
	res := characterReplacement(s, k)
	fmt.Println(res)
}

//You are given a string s, and integer k. You can choose any character o fthe string and change it to any other uppercase
//English character.You can perform this operation at most k times.
//Return the length of the longest substring containing the same letter you can get after performing the above operations.
func characterReplacement(s string, k int) int {

	var frequency = make(map[byte]int, 26)

	left := 0
	right := 0
	max := 0
	maxFrequency := 0

	for right < len(s) {
		frequency[s[right]]++

		for _, f := range frequency {
			maxFrequency = Max(maxFrequency, f)
		}

		substringLength := right - left + 1

		if substringLength-maxFrequency <= k {
			max = Max(max, substringLength)
			right++
		} else {
			frequency[s[left]]--
			frequency[s[right]]--
			left++
		}
	}

	return max
}

func Max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
