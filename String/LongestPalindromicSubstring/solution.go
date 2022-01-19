package main

import "fmt"

func main() {
	str := "abba"
	res := longestPalindrome(str)
	fmt.Println(res)
}

//racecar
//aabbaa
func longestPalindrome(s string) string {
	var substrStart, substrEnd int
	for i := 0; i < len(s); i++ {
		case1 := expandFromMiddle(s, i, i+1)
		case2 := expandFromMiddle(s, i-1, i+1)

		if case1[1]-case1[0] > substrEnd-substrStart {
			substrStart = case1[0]
			substrEnd = case1[1]
		} else if case2[1]-case2[0] > substrEnd-substrStart {
			substrStart = case2[0]
			substrEnd = case2[1]
		}
	}
	return s[substrStart : substrEnd+1]
}

func expandFromMiddle(s string, left, right int) [2]int {

	for left >= 0 && right <= len(s)-1 && s[left] == s[right] {
		left--
		right++
	}

	return [2]int{left + 1, right - 1}
}

func Max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
