package main

import (
	"fmt"
	"strings"
)

func main() {
	var d = 0.72
	fmt.Println(printBinary(d))
}

func printBinary(n float64) string {
	if n >= 1 || n <= 0 {
		return "ERROR"
	}

	var sb strings.Builder
	sb.WriteString(".")

	for n > 0 {

		r := n * 2

		if r >= 1 {
			sb.WriteString("1")
			n = r - 1
		} else {
			sb.WriteString("0")
			n = r
		}
	}

	return sb.String()
}
