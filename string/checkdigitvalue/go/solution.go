package main

import (
	"fmt"
)

//https://leetcode.com/problems/check-if-number-has-equal-digit-count-and-digit-value/
func main() {
	var num = "1210"
	r := digitCount(num)
	fmt.Println(r)
}

func digitCount(num string) bool {

	var freq [10]byte
	var n = len(num)

	for i := 0; i < n; i++ {
		var digit = num[i]

		//1. Convert char to int | "0" -> 0 | "1" > 1 | "2" > 2 | "3" -> 3
		freq[digit - 48]++
	}

	for i := 0; i < n; i++ {
		var expectedOccurence = num[i] - 48

		if expectedOccurence != freq[i] {
			return false
		}
	}

	return true
}
