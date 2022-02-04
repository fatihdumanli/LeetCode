package main

import "fmt"

func main() {
	s := "rarar"
	_ = s
	res := palindromePermutation(s)
	fmt.Println(res)
}

func palindromePermutation(s string) bool {
	//aaabbaaa
	//racecar
	var freq [26]int

	for _, c := range s {
		if c == ' ' {
			continue
		}
		isUppercase := isUppercase(c)

		if isUppercase {
			c += 32
		}
		freq[c-97]++
	}

	oddCount := 0
	for _, c := range freq {
		if c == 0 {
			continue
		}
		if c%2 == 1 {
			oddCount++
		}
	}

	return oddCount <= 1
}

func isUppercase(r rune) bool {
	if r >= 65 && r <= 90 {
		return true
	}
	return false
}
