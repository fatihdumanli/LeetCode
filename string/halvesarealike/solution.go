package main

import "fmt"

//https://leetcode.com/problems/determine-if-string-halves-are-alike/
func main() {
	s := "book"
	r := halvesAreAlike(s)
	fmt.Println(r)
}

func halvesAreAlike(s string) bool {

	var isVowel = func(a byte) bool {
		return a == 'a' || a == 'e' || a == 'i' || a == 'o' || a == 'u' || a == 'A' || a == 'E' || a == 'I' || a == 'O' || a == 'U'
	}

	var firstHalf = 0
	var secondHalf = 0
	var middle = (len(s) - 1) / 2

	for i := 0; i < len(s); i++ {

		if isVowel(s[i]) && i <= middle {
			firstHalf++
		} else if isVowel(s[i]) && i > middle {
			secondHalf++
		}
	}

	return firstHalf == secondHalf
}
