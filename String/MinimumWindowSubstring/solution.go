package main

import "fmt"

func main() {
	s := "anagram"
	t := "nagaram"
	res := isAnagram(s, t)
	fmt.Println(res)
}

func isAnagram(s string, t string) bool {

	if len(s) != len(t) {
		return false
	}

	var freq = make(map[byte]int, 26)

	for _, c := range s {
		freq[byte(c)]++
	}

	for _, c := range t {
		freq[byte(c)]--
	}

	for _, e := range freq {
		if e != 0 {
			return false
		}
	}

	return true
}
