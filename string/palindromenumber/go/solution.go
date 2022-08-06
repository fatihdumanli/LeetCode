package main

import "fmt"

func main() {
	fmt.Println(isPalindrome(12))
}

func isPalindrome(x int) bool {
	var s = fmt.Sprint(x)

	if len(s) == 1 {
		return true
	}

	var left = 0
	var right = len(s) - 1

	for s[left] == s[right] && right >= left {
		left++
		right--
	}

	return right <= left
}
