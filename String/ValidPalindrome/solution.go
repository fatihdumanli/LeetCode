package main

import "fmt"

func main() {
	s := "A man, a plan, a canal: Panama"
	fmt.Println(isPalindrome(s))
}

/*
A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric
characters, it reads the same forward and backward.
Alphanumeric characters include letters and numbers.
*/
func isPalindrome(s string) bool {

	left := 0
	right := len(s) - 1
	for left < right {
		if !isAlphanumberic(s[left]) {
			left++
			continue
		}
		if !isAlphanumberic(s[right]) {
			right--
			continue
		}

		leftChar := s[left]
		rightChar := s[right]

		if leftChar >= 65 && leftChar <= 90 {
			leftChar += 32
		}

		if rightChar >= 65 && rightChar <= 90 {
			rightChar += 32
		}

		if leftChar != rightChar {
			return false
		}
		left++
		right--
	}

	return true
}

func isAlphanumberic(c byte) bool {
	return (c >= 48 && c <= 57) || (c >= 65 && c <= 90) || (c >= 97 && c <= 122)
}
