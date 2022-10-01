package main

import "fmt"

func main() {
	var s = "||*"
	queries := [][]int{{2, 2}}
	r := platesBetweenCandles(s, queries)
	fmt.Println(r)
}

func platesBetweenCandles(s string, queries [][]int) []int {
	var answer []int = make([]int, len(queries))

	var prev []int = make([]int, len(s))
	var next []int = make([]int, len(s))
	var prefix []int = make([]int, len(s))

	lastCandle := -1

	for i := 0; i < len(prev); i++ {
		if s[i] == '|' {
			lastCandle = i
		}
		prev[i] = lastCandle
	}

	lastCandle = -1

	for i := len(next) - 1; i >= 0; i-- {
		if s[i] == '|' {
			lastCandle = i
		}
		next[i] = lastCandle
	}

	var sum = 0
	for i := 0; i < len(s); i++ {
		if s[i] == '|' {
			sum++
		}
		prefix[i] = sum
	}

	for i, q := range queries {
		var firstCandle = next[q[0]]
		var lastCandle = prev[q[1]]

		if firstCandle == -1 || lastCandle == -1 {
			continue
		}

		var totalCandlesBetween = prefix[lastCandle] - prefix[firstCandle] - 1

		total := lastCandle - firstCandle - 1
		total -= totalCandlesBetween

		if total < 0 {
			answer[i] = 0
			continue
		}

		answer[i] = total
	}

	return answer
}
