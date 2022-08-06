package main

import "fmt"

func main() {
	var s = "ilovecodingonleetcode"
	var t = "code"
	var r = rearrangeCharacters(s, t)
	fmt.Println(r)
}

func rearrangeCharacters(s string, target string) int {

	var occurences map[byte]int = make(map[byte]int)

	for i := 0; i < len(s); i++ {
		if _, contains := occurences[s[i]]; !contains {
			occurences[s[i]] = 1
		} else {
			occurences[s[i]]++
		}
	} 

	var counter = 0

	for {
		for i := 0; i < len(target); i++ {
			var charNeeded = target[i]

			if val, contains := occurences[charNeeded]; !contains || val == 0 {
				return counter
			}

			occurences[charNeeded]--
		}

		counter++
	}
}