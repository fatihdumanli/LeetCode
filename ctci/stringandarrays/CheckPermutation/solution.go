package main

import "fmt"

func main() {
	s1 := "abbaa"
	s2 := "bbaaa"

	fmt.Println(s1, s2)
	fmt.Println(checkPermutation(s1, s2))

}

//Returns true of s2 is a permutation of s1
func checkPermutation(s1, s2 string) bool {
	//O (N Log N) but space optimized solution would be sorting the strings and then if sorted strings are equal.
	if len(s1) != len(s2) {
		return false
	}

	var freq [128]int
	for i := 0; i < len(s1); i++ {
		freq[s1[i]]++
	}

	for i := 0; i < len(s2); i++ {
		freq[s2[i]]--
		if freq[s2[i]] < 0 {
			return false
		}
	}
	return true
}
