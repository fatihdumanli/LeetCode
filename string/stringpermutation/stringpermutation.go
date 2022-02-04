package main

import (
	"fmt"
	"strings"
)

var result []string

func main() {
	permuteString("", "golang")
	fmt.Printf("%d permutations found.\n", len(result))

}

func permuteString(prefix string, rem string) {
	if len(rem) == 0 {
		result = append(result, prefix)
		return
	}
	//first char of remaining is important
	//we need to swap everyting with the first character of the remaining.
	for i := 0; i < len(rem); i++ {
		//swap ith char with rem[0]
		//and trigger the next recursion.
		s := swap(rem, 0, i)
		p := prefix + string(s[0])
		newRem := s[1:]
		permuteString(p, newRem)
	}

}

func swap(s string, i int, j int) string {
	ith := s[i]
	jth := s[j]
	var sb strings.Builder
	for m := 0; m < len(s); m++ {
		if m == i {
			sb.WriteByte(jth)
			continue
		}

		if m == j {
			sb.WriteByte(ith)
			continue
		}
		sb.WriteByte(s[m])
	}

	return sb.String()
}
