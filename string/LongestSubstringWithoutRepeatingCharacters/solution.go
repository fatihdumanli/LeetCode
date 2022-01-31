package main

import "fmt"

func main() {
	s := "pwwkew"
	//abccbcbb
	res := lengthOfLongestSubstring(s)
	fmt.Println(res)
}

func lengthOfLongestSubstring(s string) int {

	if len(s) == 0 {
		return 0
	}

	if len(s) == 1 {
		return 1
	}

	var hashset map[byte]bool
	hashset = make(map[byte]bool, len(s))
	left := 0
	right := 1
	hashset[s[left]] = true

	max := 0
	for {
		// 			p  w  w  k  e  w
		if hashset[s[right]] {
			//Shrink the window
			for hashset[s[right]] {
				hashset[s[left]] = false
				left++
			}
		}

		hashset[s[right]] = true
		max = Max(max, (right-left)+1)
		right++
		if right > len(s)-1 {
			break
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
