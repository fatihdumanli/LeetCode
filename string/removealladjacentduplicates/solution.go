package main

import (
	"fmt"
	"strings"
)

func main() {
	//s := "zaddazbaabceeck"
	//s := "difdaffcca"
	s := "aaaaaaaaa"
	/*
		s := "zaddazbaabceeck"

		// affcca
		// a..cca
		// a....a


		// aaaaaaaaa
		// ..aaaaaaa
		// ..aaaaaaa
	*/
	r := removeDuplicates(s)
	fmt.Println(r)
}

// affcca
func removeDuplicates(s string) string {

	if len(s) <= 1 {
		return s
	}

	var arr []byte = make([]byte, len(s))

	for i := 0; i < len(s); i++ {
		arr[i] = s[i]
	}

	var findNextLetterIdx = func(from int) int {
		for i := from; i < len(s); i++ {
			if arr[i] != '.' {
				return i
			}
		}

		return -1
	}

	var left = 0
	var right = 1

	for right < len(s) && left != -1 && right != -1 {
		if arr[left] == arr[right] {
			r := expandFromMiddle(arr, left, right)
			for i := r[0]; i <= r[1]; i++ {
				arr[i] = '.'
			}
		    left = findNextLetterIdx(0)
		    right = findNextLetterIdx(left + 1)
		} else {
		    left = findNextLetterIdx(left + 1)
		    right = findNextLetterIdx(left + 1)
		}
	}

	var sb strings.Builder

	for i := 0; i < len(arr); i++ {
		if arr[i] != '.' {
			sb.WriteByte(arr[i])
		}
	}

	return sb.String()
}

func Min(a, b int) int {
	if a < b {
		return a
	}
	return b
}

func expandFromMiddle(s []byte, i, j int) []int {
	var isInBoundaries = func(i int) bool {
		return i >= 0 && i < len(s)
	}

	for isInBoundaries(i) && isInBoundaries(j) && s[i] == s[j] && s[i] != '.' && s[j] != '.' {
		i--
		j++
	}
	i++
	j--
	return []int{i, j}
}
