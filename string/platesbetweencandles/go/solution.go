package main

import (
	"fmt"
)

func main() {

	//s := "***|**|*****|**||**|*"
	//queries := [][]int{{1, 17}, {4, 5}, {14, 17}, {5, 11}, {15, 16}}
	s := "***"
	queries := [][]int{{2, 2}}
	r := platesBetweenCandles(s, queries)
	fmt.Println(r)
}

func platesBetweenCandles(s string, queries [][]int) []int {
	var answer []int = make([]int, len(queries))
	var candles []int

	for i := 0; i < len(s); i++ {
		if s[i] == '|' {
			candles = append(candles, i)
		}
	}

	if len(candles) < 2 {
		return answer
	}

	for i, q := range queries {
		var firstCandleIdx = lowerBound(candles, q[0], 0, len(candles)-1)
		var lastCandleIdx = findGreatestSmallerNumber(candles, q[1], 0, len(candles)-1)

		if lastCandleIdx-firstCandleIdx < 1 {
			continue
		}

		var total = candles[lastCandleIdx] - candles[firstCandleIdx] - 1
		totalCandles := lastCandleIdx - firstCandleIdx - 1
		total -= totalCandles

		if total < 0 {
			answer[i] = 0
			continue
		}

		answer[i] = total
	}

	return answer
}

func lowerBound(arr []int, num int, start int, end int) int {

	if start >= end {
		return start
	}

	var mid = start + (end-start)/2

	if arr[mid] == num {
		return mid
	} else if arr[mid] < num {
		start = mid + 1
		return lowerBound(arr, num, start, end)
	} else if arr[mid] > num {
		end = mid
		return lowerBound(arr, num, start, end)
	}
	return 0
}

func findGreatestSmallerNumber(arr []int, num, start int, end int) int {
	if start >= end {
		return start
	}

	if end-start == 1 {
		if arr[end] > num {
			return start
		}
		return end
	}

	var mid = start + (end-start)/2

	if arr[mid] == num {
		return mid
	}
	if arr[mid] < num {
		start = mid
		return findGreatestSmallerNumber(arr, num, start, end)
	} else if arr[mid] > num {
		end = mid - 1
		return findGreatestSmallerNumber(arr, num, start, end)
	}

	return 0
}
