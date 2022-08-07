package main

import "fmt"

func main() {
	dna := "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT"
	//dna := "AAAAAAAAAAAAA"
	r := findRepeatedDnaSequences(dna)
	fmt.Println(r)
}

func findRepeatedDnaSequences(s string) []string {
	var result []string
	var hashset map[string]int = make(map[string]int)

	var left = 0
	var right = 9

	for right < len(s) {
		var seq = s[left:right+1]

		if _, contains := hashset[seq]; !contains {
			hashset[seq] = 1
		} else {
			hashset[seq]++
		}
		left++
		right++
	}

	for k,v := range hashset {
		if v > 1 {
			result = append(result, k)
		}
	}

	return result
}