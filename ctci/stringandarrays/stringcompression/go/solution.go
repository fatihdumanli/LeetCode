package main

import (
	"fmt"
	"strings"
)

func main() {
	var s = "aabcccccaaa"
	s = "aaaaAAcppRRRa"
	compressed := compressString(s)
	fmt.Println(compressed)
}

func compressString(s string) string {
	/*
		aabcccccaaa => a2b1c5a3
		the strings comprises of only lowercase and uppercase letters

		if the compressed string is longer than the original one, return the original string
	*/

	var sb strings.Builder
	var cur = s[0]
	sb.WriteByte(cur)
	var count = 1

	for i := 1; i < len(s); i++ {
		if s[i] != cur {
			cstring := fmt.Sprintf("%d", count)
			sb.WriteString(cstring)
			cur = s[i]
			sb.WriteByte(cur)
			count = 1
		} else {
			count++
		}
	}

	cstring := fmt.Sprintf("%d", count)
	sb.WriteString(cstring)

	if len(sb.String()) <= len(s) {
		return sb.String()
	}
	return s
}
