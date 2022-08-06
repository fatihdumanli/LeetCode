package main

import (
	"fmt"
	"strings"
)

func main() {
	//var word = "a123bc34d8ef34fgh1abc01"
	var word = "01i00e"
	var r = numDifferentIntegers(word)
	fmt.Println(r)
}

func numDifferentIntegers(word string) int {
	var isDigit = func(b byte, zeroIncluded bool) bool {
		var ascii = int(b)
		if zeroIncluded {
			return ascii >= 48 && ascii <= 57
		}
		return ascii >= 49 && ascii <= 57
	}

	var isLeadingZero = func(i int) bool {
		if i == len(word)-1 {
			return false
		}

		for int(word[i]) == 48 {
			i++
		}
		if isDigit(word[i], false) {
			return true
		}

		return false
	}

	var sb strings.Builder
	var numbers = make(map[string]bool)
	var counter = 0

	hasEncounteredANumber := false

	for i := 0; i < len(word); i++ {
		if !hasEncounteredANumber && int(word[i]) == 48 && !isLeadingZero(i) {
			if _, contains := numbers["0"]; !contains {
				numbers["0"] = true
				counter++
			}
		} else if !hasEncounteredANumber && isDigit(word[i], false) {
			hasEncounteredANumber = true
			sb.WriteByte(word[i])
		} else if hasEncounteredANumber && isDigit(word[i], true) {
			sb.WriteByte(word[i])
		} else if hasEncounteredANumber && !isDigit(word[i], true) {
			hasEncounteredANumber = false

			var num = sb.String()
			if _, contains := numbers[num]; !contains {
				numbers[num] = true
				counter++
			}
			sb.Reset()
		}
	}

	if sb.Len() > 0 {
		var num = sb.String()
		if _, contains := numbers[num]; !contains {
			numbers[num] = true
			counter++
		}
	}

	return counter
}
