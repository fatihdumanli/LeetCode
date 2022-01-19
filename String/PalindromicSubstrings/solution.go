package main

import "fmt"

func main() {
	s := "aaa"
	res := countSubstrings(s)
	fmt.Println(res)
}

func countSubstrings(s string) int {
	var numberOfPalindromes int

	for i := 0; i < len(s); i++ {
		numberOfPalindromes++

		case1 := expandFromMiddle(s, i, i+1)
		case2 := expandFromMiddle(s, i-1, i+1)

		numberOfPalindromes += case1
		numberOfPalindromes += case2
	}
	return numberOfPalindromes
}

func expandFromMiddle(s string, left, right int) int {
	palindromes := 0
	for left >= 0 && right < len(s) && s[left] == s[right] {
		left--
		right++
		palindromes++
	}
	return palindromes
}
