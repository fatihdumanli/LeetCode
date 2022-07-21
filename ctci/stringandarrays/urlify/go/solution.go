package main

import (
	"fmt"
	"strings"
)

func main() {
	s := "Mr    john    Smith  "
	var r = URLify(s, 13)
	fmt.Println(r)
}

func URLify(s string, l int) string {

	var sb strings.Builder
	var i, c int = 0, 0

	for c < l {
		var cur = string(s[i])
		var soFar = sb.String()
		_ = soFar

		if cur == " " {
			for i < len(s) && cur == " " {
				i++
				cur = string(s[i])
			}

			sb.WriteString("%20")
			c++
		} else {
			sb.WriteString(cur)
			i++
			c++
		}

	}

	return sb.String()
}
