package main

import (
	"fmt"
	"sort"
)

//https://leetcode.com/problems/determine-if-two-strings-are-close/
func main() {
	s1 := "cabbba"
	s2 := "abbccc"
	fmt.Println(closeStrings(s1, s2))
}

func closeStrings(word1 string, word2 string) bool {

	if len(word1) != len(word2) {
		return false
	}

	var freq1 []int = make([]int, 26)

	for i := 0; i < len(word1); i++ {
		var ascii = word1[i]
		freq1[ascii-'a']++
	}

	var freq2 []int = make([]int, 26)
	for i := 0; i < len(word2); i++ {
		var ascii = word2[i]
		freq2[ascii-'a']++
	}

	for i := 0; i < 26; i++ {
		if (freq1[i] == 0 && freq2[i] != 0) || (freq1[i] != 0 && freq2[i] == 0) {
			return false
		}
	}

	sort.Ints(freq1)
	sort.Ints(freq2)

	for i := 0; i < 26; i++ {
		if freq1[i] != freq2[i] {
			return false
		}
	}

	return true
}
