package main

import (
	"fmt"
	"math"
	"strings"
)

func main() {
	var strs = []string{"flower", "flight", "flow"}
	result := longestCommonPrefix(strs)
	fmt.Println(result)
}

//flower, flow, flight
func longestCommonPrefix(strs []string) string {

	var minLength = math.MaxInt32
	var shortest string

	for _, str := range strs {
		if len(str) < minLength {
			minLength = len(str)
			shortest = str
		}
	}

	var builder strings.Builder

	for i := 0; i < minLength; i++ {
		cur := shortest[i]

		for _, str := range strs {
			if str[i] != cur {
				return builder.String()
			}
		}
		builder.WriteByte(cur)
	}

	return builder.String()
}
