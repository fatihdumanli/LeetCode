package main

import "fmt"

func main() {
	s := "abcdefa"
	result := isUnique(s)
	fmt.Println(result)
}

//what if you cannot use any additional ds?
func isUnique(s string) bool {

	if len(s) > 128 {
		return false
	}
	var freq [128]bool

	for _, c := range s {
		if freq[c] {
			return false
		}
		freq[c] = true
	}

	return true
}
