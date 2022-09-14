package main

import (
	"fmt"
	"strings"
)

func main() {
	var s = "ddadddbdddadd"
	wordDict := []string{"dd", "ad", "da", "b"}
	//	"dd ad dd b dd da dd"
	//	["dd","ad","da","b"]
	//var s = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab"
	//wordDict := []string{"a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa"}
	var result = wordBreak(s, wordDict)
	fmt.Println(result)
}

func wordBreak(s string, wordDict []string) bool {
	var result = helper(s, wordDict, "")
	return result
}

func helper(s string, wordDict []string, branch string) bool {

	if branch != "" {
		s = strings.Replace(s, branch, "X", -1)
	}

	if allX(&s) {
		return true
	}

	for i := 0; i < len(wordDict); i++ {

		var branch = wordDict[i]

		if s == "ddadddbdddadd" {
			var x = 2
			_ = x
		}

		if !strings.Contains(s, branch) {
			continue
		}

		res := helper(s, wordDict, branch)
		if res {
			return true
		}
	}

	return false
}

func allX(s *string) bool {
	for i := 0; i < len(*s); i++ {
		if (*s)[i] != 'X' {
			return false
		}
	}
	return true
}
