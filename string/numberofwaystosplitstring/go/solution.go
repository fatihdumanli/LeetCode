package main

import "fmt"

func main() {
	s := "01001001"
	r := numWays(s)

	fmt.Println(r)
}

func numWays(s string) int {

	total := 0

	for _, c := range s {
		if c == '1' {
			total++
		}
	}

	if total%3 != 0 {
		return 0
	}

	need := total / 3

	result := intp(0)

	permute(s, 0, 0, 1, need, result)

	return *result
}

func permute(s string, start int, end int, total int, need int, result *int) {
	if end >= len(s) {
		return
	}

	if total == 3 {
		*result++
		return
	}

	ones := 0

	for i := 0; i < len(s); i++ {
		if end < len(s) && s[end] == '1' {
			ones++
		}
		if ones > need {
			return
		} else if ones == need {
			permute(s, end+1, end+1, total+1, need, result)
		}
		end++
	}
}

func intp(val int) *int {
	return &val
}
