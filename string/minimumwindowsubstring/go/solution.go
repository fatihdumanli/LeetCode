package main

import (
	"fmt"
	"math"
)

func main() {
	s := "ADOBECODEBANC"
	t := "ABC"
	result := minWindow(s, t)
	fmt.Println(result)
}

func minWindow(s string, t string) string {
	if len(t) > len(s) {
		return ""
	}

	var needs map[rune]int = make(map[rune]int, 0)
	for _, r := range t {
		_, ok := needs[r]
		if !ok {
			needs[r] = 1
		} else {
			needs[r]++
		}
	}

	left, right := 0, 0
	var minWindow string
	var minWindowLength = math.MaxInt32

	for right <= len(s) && left <= right {

		if doesSatisfy(needs) {
			if right-left < minWindowLength {
				minWindow = s[left:right]
				minWindowLength = len(minWindow)
			}

			//shrink the window
			_, ok := needs[rune(s[left])]
			if ok {
				needs[rune(s[left])]++
			}
			left++
		} else {
			//expand the window
			if right < len(s) {
				_, ok := needs[rune(s[right])]
				if ok {
					needs[rune(s[right])]--
				}
			}
			right++
		}

	}

	if doesSatisfy(needs) && right-left < minWindowLength {
		minWindow = s[left:right]
		minWindowLength = len(minWindow)
	}

	return minWindow
}

func doesSatisfy(m map[rune]int) bool {
	for _, v := range m {
		if v > 0 {
			return false
		}
	}

	return true
}
